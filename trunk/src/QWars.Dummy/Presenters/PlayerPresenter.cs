using QWars.Dummy.Entities;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.Dummy.Presenters
{
    public class PlayerPresenter : IPlayerPresenter
    {
        private readonly Logger logger;
        private readonly IPlayerView view;

        public PlayerPresenter(IPlayerView view)
        {
            logger = new Logger(this);
            this.view = view;
        }

        public void Initialize()
        {
            UpdateView();
        }

        public void MugPedestrian()
        {
            logger.Log(string.Format("Player {0} mugs a pedestrian", view.Player));
            GetPlayer().Execute(new Mugging());
            UpdateView();
        }

        public void SellUnusedWeapons()
        {
            logger.Log(string.Format("Player {0} sells his unused weapons", view.Player));
            GetPlayer().SellUnusedWeapons();
            UpdateView();
        }

        public void UpdateView()
        {
            var player = GetPlayer();
            view.Title = string.Format("{0}", player.Name);
            view.Money = player.Money;
            view.XP = player.XP;
            view.Weapons = player.Weapons;
        }

        private IPlayer GetPlayer()
        {
            return InMemoryRepository.FindPlayer(view.Player.Id);
        }
    }
}