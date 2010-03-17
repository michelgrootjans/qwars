using System.Collections.Generic;
using System.Linq;
using QWars.Dummy.Entities;
using QWars.Presentation;
using QWars.Presentation.Entities;

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
        }

        public void Initialize()
        {
            members = new List<Player>
                          {
                              new Player(1, "Calamity Jane"),
                              new Player(2, "Jon Shannow")
                          };
            tasks = new List<Task>{new Task("Burn the police station")};
            UpdateView();
        }

        public void CreateRandomTasks()
        {
            const int numberOfTasks = 20;
            logger.Log(string.Format("Boss {0} creates {1} random tasks", view.Player, numberOfTasks));
            for (var i = 0; i < numberOfTasks; i++)
                tasks.Add(new Task("mug someone"));
            UpdateView();
        }

        public void IncreaseRewardForAllTasks()
        {
            logger.Log(string.Format("Boss {0} increases reward for all tasks with 15%", view.Player));
        }

        private void UpdateView()
        {
            view.GangName = "The Flowerpot Men";
            view.GangMoney = 255;
            view.NumberOfMembers = members.Count;
            view.Members = members.Cast<IPlayer>();
            view.Tasks = tasks.Cast<ITask>();
        }
    }
}