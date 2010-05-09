using NHibernate;

namespace NHibernateDemo.Utilities
{
    public interface IDatabaseContext
    {
        ISession GetSession();
    }
}