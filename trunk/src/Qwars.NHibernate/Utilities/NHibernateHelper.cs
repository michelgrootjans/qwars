using NHibernate;
using NHibernate.Cfg;

namespace QWars.NHibernate.Utilities
{
    public static class NHibernateHelper
    {
        private static readonly ISessionFactory sessionFactory;

        static NHibernateHelper()
        {
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public static ISession CreateSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}