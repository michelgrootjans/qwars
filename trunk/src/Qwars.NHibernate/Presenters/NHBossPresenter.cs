using System.Linq;
using QWars.NHibernate.Entities;
using QWars.Presentation;
using QWars.Presentation.Entities;

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
            {
                var boss = Get<IBoss>(view.Player.Id, session);
                UpdateView(boss);
            }
        }

        public void CreateRandomTasks()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                const int numberOfTasks = 20;

                var boss = Get<IBoss>(view.Player.Id, session);
                for (var i = 0; i < numberOfTasks; i++)
                    boss.CreateTask("Mug someone", 0, 15, 20);
                UpdateView(boss);
                transaction.Commit();
            }
        }

        public void IncreaseRewardForAllTasks()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var boss = Get<IBoss>(view.Player.Id, session);
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