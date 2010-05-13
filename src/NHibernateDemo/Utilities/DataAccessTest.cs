using NHibernate;
using NHibernateDemo.Entities;
using NUnit.Framework;

namespace NHibernateDemo.Utilities
{
    [TestFixture]
    public abstract class DataAccessTest
    {
        private static readonly bool inMemoryDatabase;
        private static readonly bool rollbaceAfterEachTests;

        protected ISession session;
        private ITransaction transaction;

        static DataAccessTest()
        {
            inMemoryDatabase = false;
            rollbaceAfterEachTests = true;
        }

        [SetUp]
        public void SetUp()
        {
            CreateNewSession();
            PrepareData();
            FlushAndClear();
        }

        private void CreateNewSession()
        {
            if (inMemoryDatabase)
                session = new InMemorySessionFactory<Player>().GetSession();
            else
                session = new ConfigurationSessionFactory().GetSession();
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

            if (rollbaceAfterEachTests)
                transaction.Rollback();
            else
                transaction.Commit();

            transaction.Dispose();
            session.Dispose();
        }
    }
}