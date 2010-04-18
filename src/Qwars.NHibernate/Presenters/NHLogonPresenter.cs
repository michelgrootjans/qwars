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
            using ( var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = session.CreateCriteria<Player>().Add(Restrictions.Eq("Name", playerName)).UniqueResult();
                if(player == null)
                {
                    player = new Player(playerName);
                    session.Save(player);
                    transaction.Commit();
                }
                return new PlayerInfo(session.GetIdentifier(player), playerName);
            }
        }
    }
}