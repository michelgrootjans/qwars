using QWars.Dummy.Entities;
using QWars.Presentation;
using QWars.Presentation.Entities;
using System.Linq;

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
            view.XP = string.Format("{0} + {1}", player.XP, player.XPBonus);
            view.Weapons = player.Weapons.ToList();
        }

        private IPlayer GetPlayer()
        {
            return InMemoryRepository.FindPlayer(view.Player.Id);
        }
    }
}