using NHibernate;
using NHibernateDemo.Entities;
using NUnit.Framework;

namespace NHibernateDemo.Utilities
{
    [TestFixture]
    public abstract class DataAccessTest
    {
        private static readonly bool useSqlServer;
        private static readonly bool rollbackTests;


        static DataAccessTest()
        {
            useSqlServer = false;
            rollbackTests = true;
        }

        [SetUp]
        public void SetUp()
        {
            CreateNewSession();
            PrepareData();
            FlushAndClear();
        }

        protected ISession session;
        private ITransaction transaction;

        private void CreateNewSession()
        {
            if (useSqlServer)
                session = new ConfigurationSessionFactory().GetSession();
            else
                session = new InMemorySessionFactory<Player>().GetSession();
            transaction = session.BeginTransaction();
        }

        protected abstract void PrepareData();

        protected void FlushAndClear()
        {
            session.Flush();
            session.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            FlushAndClear();
            if (rollbackTests)
                transaction.Rollback();
            else
                transaction.Commit();
            transaction.Dispose();
            session.Dispose();
        }
    }
}