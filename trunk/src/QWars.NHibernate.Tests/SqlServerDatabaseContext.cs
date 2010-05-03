using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace QWars.NHibernate.Tests
{
    public class SqlServerDatabaseContext: IDatabaseContext
    {
        private static ISessionFactory sessionFactory;
        private ISession session;
        private ITransaction transaction;

        public ISession GetSession()
        {
            if (sessionFactory == null)
            {
                /// Initialize NHibernate and builds a session factory
                /// Note: this is a costly call so it will be executed only once.            
                NHibernateProfiler.Initialize();
                var configuration = new Configuration().Configure();
                sessionFactory = configuration.BuildSessionFactory();
                new SchemaExport(configuration).Create(false, true);
            }

            session = sessionFactory.OpenSession();
            transaction = session.BeginTransaction();
            return session;
        }

        public void FlushAndClear()
        {
            session.Flush();
            session.Clear();
        }

        public void Rollback()
        {
            transaction.Rollback();
            transaction.Dispose();
            session.Dispose();
        }
    }
}