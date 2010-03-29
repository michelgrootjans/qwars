using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace QWars.NHibernate.Tests
{
    [TestFixture]
    public abstract class DataAccessTest
    {
        private static ISessionFactory sessionFactory;
        protected ISession session;
        private ITransaction transaction;

        [SetUp]
        public void SetUp()
        {
            if (sessionFactory == null)
            {
                /// Initialize NHibernate and builds a session factory
                /// Note: this is a costly call so it will be executed only once.            
                NHibernateProfiler.Initialize();
                var configuration = new Configuration().Configure();
                sessionFactory = configuration.BuildSessionFactory();
                new SchemaExport(configuration).Create(false, true);
            }
            session = sessionFactory.OpenSession();
            transaction = session.BeginTransaction();
            PrepareData();
            session.Flush();
            session.Clear();
        }

        protected abstract void PrepareData();

        [TearDown]
        public void TearDown()
        {
            transaction.Commit();
            transaction.Dispose();
            session.Dispose();
        }
    }
}