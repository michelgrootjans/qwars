using NHibernate;

namespace QWars.NHibernate.Tests
{
    public interface IDatabaseContext
    {
        ISession GetSession();
        void FlushAndClear();
        void Rollback();
        void Commit();
    }
}