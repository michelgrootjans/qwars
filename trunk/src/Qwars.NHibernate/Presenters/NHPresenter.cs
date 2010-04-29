using NHibernate;
using NHibernate.Cfg;
using QWars.NHibernate.Entities;
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

        //protected void Execute(object playerId, Action<IPlayer> action)
        //{
        //    using (var session = sessionFactory.OpenSession())
        //    using (var transaction = session.BeginTransaction())
        //    {
        //        var player = session.Get<Player>(playerId);
        //        action(player);
        //        transaction.Commit();
        //    }
        //}

        //protected INHibernateAction<IPlayer> Get(object playerId)
        //{
        //    return new PlayerAction(playerId, sessionFactory);
        //}
        protected IPlayer GetPlayer(object playerId, ISession session)
        {
            return session.Get<Player>(playerId);
        }
    }
}