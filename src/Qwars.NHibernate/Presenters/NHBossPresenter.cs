using System.Linq;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Presenters
{
    public class NHBossPresenter : NHPresenter, IBossPresenter
    {
        private readonly IBossView view;

        public NHBossPresenter(IBossView view)
        {
            this.view = view;
        }

        public void Initialize()
        {
            using (var transaction = session.BeginTransaction())
            {
                var boss = Get<IBoss>(view.Player.Id);
                UpdateView(boss);
                transaction.Commit();
            }
        }

        public void CreateRandomTasks()
        {
            using (var transaction = session.BeginTransaction())
            {
                const int numberOfTasks = 20;

                var boss = Get<IBoss>(view.Player.Id);
                for (var i = 0; i < numberOfTasks; i++)
                    boss.CreateTask("Ransom task", 0, 15, 20);
                UpdateView(boss);
                transaction.Commit();
            }
        }

        public void IncreaseRewardForAllTasks()
        {
            using (var transaction = session.BeginTransaction())
            {
                var boss = Get<IBoss>(view.Player.Id);
                boss.IncreaseAllRewardsWith(0.15);
                UpdateView(boss);
                transaction.Commit();
            }
        }

        private void UpdateView(IBoss boss)
        {
            view.GangName = boss.GangName;
            view.GangMoney = boss.GangMoney;
            view.NumberOfMembers = boss.GangMembers.Count();
            view.Members = boss.GangMembers;
            view.Tasks = boss.GetGangTasks();
        }
    }
}