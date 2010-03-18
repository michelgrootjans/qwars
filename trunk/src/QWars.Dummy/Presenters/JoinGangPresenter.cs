using QWars.Presentation;

namespace QWars.Dummy.Presenters
{
    public class JoinGangPresenter : IJoinGangPresenter
    {
        private readonly IJoinGangView view;
        private readonly Logger logger;

        public JoinGangPresenter(IJoinGangView view)
        {
            this.view = view;
            logger = new Logger(this);
        }

        public void Initialize()
        {
            view.Gangs = InMemoryRepository.GetAllGangs();
        }

        public void JoinGang()
        {
            logger.Log(string.Format("Player {0} joins '{1}'", view.Player, view.SelectedGang));
            var player = InMemoryRepository.FindPlayer(view.Player.Id);
            var gang = view.SelectedGang;
            player.Join(gang);
        }
    }
}