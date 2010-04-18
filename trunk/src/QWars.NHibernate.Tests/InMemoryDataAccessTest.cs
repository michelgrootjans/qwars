using System;
using System.IO;
using System.Text;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Environment=NHibernate.Cfg.Environment;

namespace QWars.NHibernate.Tests
{
    public abstract class InMemoryDatabaseTest<T> : IDisposable
    {
        private static Configuration configuration;
        private static ISessionFactory sessionFactory;
        protected ISession session;

        protected InMemoryDatabaseTest()
        {
            if (configuration != null) return;

            NHibernateProfiler.Initialize();

            /// Initialize NHibernate and builds a session factory
            /// Note: this is a costly call so it will be executed only once.            
            configuration = new Configuration()
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.Dialect, typeof (SQLiteDialect).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionDriver, typeof (SQLite20Driver).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, "data source=:memory:")
                .SetProperty(Environment.ProxyFactoryFactoryClass,
                             typeof (ProxyFactoryFactory).AssemblyQualifiedName)
                .AddAssembly(typeof (T).Assembly);

            sessionFactory = configuration.BuildSessionFactory();
        }

        [SetUp]
        public void SetUp()
        {
            // create a new NH session
            session = sessionFactory.OpenSession();

            // create a clean in mem database schema
            new SchemaExport(configuration).Execute(false, true, false, session.Connection, new NullOutputter());

            // fill the DB with setup data
            PrepareData();

            // commit setup data before exectuing the test
            session.Flush();

            // clear the level 1 cache
            session.Clear();
        }


        protected abstract void PrepareData();

        public void Dispose()
        {
            session.Dispose();
        }
    }

    class NullOutputter : TextWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}