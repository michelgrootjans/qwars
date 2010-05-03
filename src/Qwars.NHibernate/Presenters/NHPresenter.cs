using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Presenters
{
    public class NHPresenter
    {
        protected static readonly ISessionFactory sessionFactory;

        static NHPresenter()
        {
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        protected T Get<T>(object entityId, ISession session) where T : class
        {
            return session.CreateCriteria<T>()
                .Add(Restrictions.IdEq(entityId))
                .UniqueResult<T>();
        }
    }
}