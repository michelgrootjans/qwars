using System.Collections.Generic;
using QWars.Dummy.Entities;
using QWars.Presentation;

namespace QWars.Dummy.Presenters
{
    public class GangMemberPresenter : IGangMemberPresenter
    {
        private readonly IGangMemberView view;
        private Logger logger;

        public GangMemberPresenter(IGangMemberView view)
        {
            this.view = view;
            logger = new Logger(this);
        }

        public void Initialize()
        {
            view.Tasks = new List<Task>
                             {
                                 new Task("Steal a car"),
                                 new Task("Poison Obama")
                             };
        }

        public void ExecuteTask()
        {
            logger.Log(string.Format("Player {0} executes {1}", view.Player, view.SelectedTask));
            var player = InMemoryRepository.FindPlayer(view.Player.Id);
            player.Execute(view.SelectedTask);
        }
    }
}