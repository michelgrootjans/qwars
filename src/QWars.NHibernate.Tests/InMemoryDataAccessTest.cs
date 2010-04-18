using System;
using System.IO;
using System.Text;
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
        private ITransaction transaction;

        protected InMemoryDatabaseTest()
        {
            if (configuration == null)
            {
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
            session = sessionFactory.OpenSession();
            new SchemaExport(configuration).Execute(false, true, false, session.Connection, new NullOutputter());
        }

        [SetUp]
        public void SetUp()
        {
            transaction = session.BeginTransaction();
            PrepareData();
            session.Flush();
            session.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            transaction.Rollback();
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