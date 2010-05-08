using NHibernate;
using NHibernateDemo.Entities;
using NUnit.Framework;
using QWars.NHibernate.Tests;

namespace NHibernateDemo.Utilities
{
    [TestFixture]
    public abstract class DataAccessTest
    {
        private static readonly bool useSqlServer;
        private static readonly bool rollbackTests;


        static DataAccessTest()
        {
            useSqlServer = true;
            rollbackTests = true;
        }

        [SetUp]
        public void SetUp()
        {
            CreateNewSession();
            PrepareData();
            FlushAndClear();
        }

        private IDatabaseContext databaseContext;
        protected ISession session;

        private void CreateNewSession()
        {
            if (useSqlServer)
                databaseContext = new SqlServerDatabaseContext();
            else
                databaseContext = new InMemoryDatabaseContext<Player>();
            session = databaseContext.GetSession();
        }

        protected abstract void PrepareData();

        protected void FlushAndClear()
        {
            databaseContext.FlushAndClear();
        }

        [TearDown]
        public void TearDown()
        {
            FlushAndClear();
            if (rollbackTests)
                databaseContext.Rollback();
            else
                databaseContext.Commit();
        }
    }
}