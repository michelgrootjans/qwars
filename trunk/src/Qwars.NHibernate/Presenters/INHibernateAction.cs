//using System;
//using NHibernate;
//using QWars.NHibernate.Entities;
//using QWars.Presentation.Entities;

//namespace QWars.NHibernate.Presenters
//{
//    public interface INHibernateAction<T>
//    {
//        void AndExecute(Action<T> action);
//    }

//    internal class PlayerAction : INHibernateAction<IPlayer>
//    {
//        private readonly object playerId;
//        private readonly ISessionFactory sessionFactory;

//        public PlayerAction(object playerId, ISessionFactory sessionFactory)
//        {
//            this.playerId = playerId;
//            this.sessionFactory = sessionFactory;
//        }

//        public void AndExecute(Action<IPlayer> action)
//        {
//            using (var session = sessionFactory.OpenSession())
//            using (var transaction = session.BeginTransaction())
//            {
//                var player = session.Get<Player>(playerId);
//                action(player);
//                transaction.Commit();
//            }
//        }
//    }

//}