using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;

namespace QWars.NHibernate.Presenters
{
    public class NHPresenter : IDisposable
    {
        protected static readonly ISessionFactory sessionFactory;
        protected readonly ISession session;

        static NHPresenter()
        {
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public NHPresenter()
        {
            session = sessionFactory.OpenSession();
        }

        protected T Get<T>(object entityId) where T : class
        {
            return session.CreateCriteria<T>()
                .Add(Restrictions.IdEq(entityId))
                .UniqueResult<T>();
        }

        public void Dispose()
        {
            if (session != null) session.Dispose();
        }
    }
}