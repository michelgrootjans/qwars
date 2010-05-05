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
            PlayerInfo playerInfo;
            using (var transaction = session.BeginTransaction())
            {
                var player = FindPlayerInDatabase(playerName) ?? CreatePlayer(playerName);
                playerInfo = new PlayerInfo(session.GetIdentifier(player), playerName);
                transaction.Commit();
            }
            return playerInfo;
        }

        private IPlayer CreatePlayer(string playerName)
        {
            var player = new Player(playerName);
            session.Save(player);
            return player;
        }

        private IPlayer FindPlayerInDatabase(string playerName)
        {
            return session.CreateCriteria<IPlayer>()
                .Add(Restrictions.Eq("Name", playerName))
                .UniqueResult<IPlayer>();
        }
    }
}