using NHibernate;
using NUnit.Framework;
using QWars.NHibernate.Entities;

namespace QWars.NHibernate.Tests
{
    [TestFixture]
    public abstract class DataAccessTest
    {
        private IDatabaseContext databaseContext;
        protected ISession session;

        [SetUp]
        public void SetUp()
        {
            databaseContext = new InMemoryDatabaseContext<Player>();
            //databaseContext = new SqlServerDatabaseContext();
            session = databaseContext.GetSession();
            PrepareData();
            databaseContext.FlushAndClear();
        }

        protected abstract void PrepareData();

        [TearDown]
        public void TearDown()
        {
            databaseContext.Rollback();
        }

        protected void FlushAndClear()
        {
            databaseContext.FlushAndClear();
        }
    }
}