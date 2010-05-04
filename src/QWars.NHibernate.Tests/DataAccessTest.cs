using NHibernate;
using NUnit.Framework;
using QWars.NHibernate.Entities;

namespace QWars.NHibernate.Tests
{
    [TestFixture]
    public abstract class DataAccessTest
    {
        private const bool USE_SQL_SERVER = true;
        private const bool ROLLBACK_TESTS = true;

        private IDatabaseContext databaseContext;
        protected ISession session;

        [SetUp]
        public void SetUp()
        {
            databaseContext = USE_SQL_SERVER
                                  ? (IDatabaseContext) new SqlServerDatabaseContext()
                                  : new InMemoryDatabaseContext<Player>();
            session = databaseContext.GetSession();
            PrepareData();
            databaseContext.FlushAndClear();
        }

        protected abstract void PrepareData();

        [TearDown]
        public void TearDown()
        {
            if(ROLLBACK_TESTS)
                databaseContext.Rollback();
            else
                databaseContext.Commit();
        }

        protected void FlushAndClear()
        {
            databaseContext.FlushAndClear();
        }
    }
}