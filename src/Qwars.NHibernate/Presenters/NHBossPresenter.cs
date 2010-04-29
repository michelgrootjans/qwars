using System.Linq;
using QWars.NHibernate.Entities;
using QWars.Presentation;

namespace QWars.NHibernate.Presenters
{
    public class NHBossPresenter :NHPresenter, IBossPresenter
    {
        private readonly IBossView view;

        public NHBossPresenter(IBossView view)
        {
            this.view = view;
        }

        public void Initialize()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player= session.Get<Player>(view.Player.Id);
                var gang = session.CreateQuery("from Gang where Boss=:boss")
                    .SetEntity("boss", player)
                    .UniqueResult<Gang>();

                view.GangName = gang.Name;
                view.GangMoney = gang.Money;
                view.Members = gang.Members;
                view.NumberOfMembers = gang.Members.Count();
                view.Tasks = gang.Tasks;
                
                transaction.Commit();
            }
        }

        public void CreateRandomTasks()
        {
        }

        public void IncreaseRewardForAllTasks()
        {
        }
    }
}