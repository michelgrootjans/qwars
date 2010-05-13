using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateDemo.Utilities
{
    public class ConfigurationSessionFactory : IDatabaseContext
    {
        private static ISessionFactory sessionFactory;

        public ISession GetSession()
        {
            if (sessionFactory == null)
            {
                NHibernateProfiler.Initialize();
                // Initialize NHibernate and builds a session factory
                // Note: this is a costly call so it will be executed only once.            
                var configuration = new Configuration().Configure();
                sessionFactory = configuration.BuildSessionFactory();
                new SchemaExport(configuration).Create(false, true);
            }

            return sessionFactory.OpenSession();
        }
    }
}