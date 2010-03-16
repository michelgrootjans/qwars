using System.Collections.Generic;
using QWars.Dummy.Entities;
using QWars.Presentation;

namespace QWars.Dummy.Presenters
{
    public class BossPresenter : IBossPresenter
    {
        private readonly IBossView view;
        private readonly Logger logger;
        private List<Player> members;
        private List<Task> tasks;

        public BossPresenter(IBossView view)
        {
            this.view = view;
            logger = new Logger(this);
            members = new List<Player>
                          {
                              new Player("Calamity Jane"),
                              new Player("Jon Shannow")
                          };
            tasks = new List<Task>();
        }

        public void Initialize()
        {
            view.GangName = "The Flowerpot Men";
            view.GangMoney = 255;
            view.Members = members;
            view.NumberOfMembers = members.Count;
            view.Tasks = tasks;
        }

        public void CreateRandomTasks()
        {
            logger.Log(string.Format("Boss {0} creates 20 random tasks", view.PlayerId));
        }

        public void IncreaseRewardForAllTasks()
        {
            logger.Log(string.Format("Boss {0} increases reward for all tasks with 15%", view.PlayerId));
        }
    }
}