using NHibernate;
using NHibernate.Criterion;
using QWars.NHibernate.Entities;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Presenters
{
    public class NHLogonPresenter : NHPresenter, ILogonPresenter
    {
        public PlayerInfo LoginWithPlayerName(string playerName)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var player = FindPlayerInDatabase(session, playerName)
                             ?? CreatePlayer(session, playerName);

                return new PlayerInfo(session.GetIdentifier(player), playerName);
            }
        }

        private object CreatePlayer(ISession session, string playerName)
        {
            object player;
            using (var transaction = session.BeginTransaction())
            {
                player = new Player(playerName);
                session.Save(player);
                transaction.Commit();
            }
            return player;
        }

        private object FindPlayerInDatabase(ISession session, string playerName)
        {
            return session.CreateCriteria<IPlayer>()
                .Add(Restrictions.Eq("Name", playerName))
                .UniqueResult<IPlayer>();
        }
    }
}