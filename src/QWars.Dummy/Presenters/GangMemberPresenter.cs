using QWars.Presentation;

namespace QWars.Dummy.Presenters
{
    public class GangMemberPresenter : IGangMemberPresenter
    {
        private readonly IGangMemberView view;
        private readonly Logger logger;

        public GangMemberPresenter(IGangMemberView view)
        {
            this.view = view;
            logger = new Logger(this);
        }

        public void Initialize()
        {
            var player = InMemoryRepository.FindPlayer(view.Player.Id);
            view.Tasks = player.GetGangTasks();
        }

        public void ExecuteTask()
        {
            logger.Log(string.Format("Player {0} executes {1}", view.Player, view.SelectedTask));
            var player = InMemoryRepository.FindPlayer(view.Player.Id);
            player.Execute(view.SelectedTask);
        }
    }
}