using System.Linq;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.Dummy.Presenters
{
    public class BossPresenter : IBossPresenter
    {
        private readonly IBossView view;
        private readonly Logger logger;

        public BossPresenter(IBossView view)
        {
            this.view = view;
            logger = new Logger(this);
        }

        public void Initialize()
        {
            UpdateView();
        }

        public void CreateRandomTasks()
        {
            const int numberOfTasks = 20;

            var boss = GetBoss();
            logger.Log(string.Format("Boss {0} creates {1} random tasks", view.Player, numberOfTasks));
            for (var i = 0; i < numberOfTasks; i++)
                boss.CreateTask("Mug someone", 0, 15, 20);
            UpdateView();
        }

        public void IncreaseRewardForAllTasks()
        {
            logger.Log(string.Format("Boss {0} increases reward for all tasks with 15%", view.Player));
            var boss = GetBoss();
            boss.IncreaseAllRewardsWith(0.15);
        }

        private void UpdateView()
        {
            var boss = GetBoss();

            view.GangName = boss.GangName;
            view.GangMoney = boss.GangMoney;
            view.NumberOfMembers = boss.GangMembers.Count();
            view.Members = boss.GangMembers;
            view.Tasks = boss.GetGangTasks();
        }

        private IBoss GetBoss()
        {
            return InMemoryRepository.FindPlayer(view.Player.Id);
        }
    }
}