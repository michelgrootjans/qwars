using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.Dummy.Presenters
{
    public class BuyWeaponsPresenter : IBuyWeaponsPresenter
    {
        private readonly IBuyWeaponsView view;
        private readonly Logger logger;

        public BuyWeaponsPresenter(IBuyWeaponsView view)
        {
            this.view = view;
            logger = new Logger(this);
        }

        public void BuyClub()
        {
            logger.Log(string.Format(Player + " buys a new Club", Player));
            Player.Buy(WeaponFactory.Club);
        }

        public void BuyKnife()
        {
            logger.Log(string.Format(Player + " buys a new Knife", Player));
            Player.Buy(WeaponFactory.Knife);
        }

        public void BuyTaser()
        {
            logger.Log(string.Format(Player + " buys a new Taser", Player));
            Player.Buy(WeaponFactory.Taser);
        }

        public void BuyGun()
        {
            logger.Log(string.Format(Player + " buys a new Gun", Player));
            Player.Buy(WeaponFactory.Gun);
        }

        public void BuyBomb()
        {
            logger.Log(string.Format(Player + " buys a new Bomb", Player));
            Player.Buy(WeaponFactory.Bomb);
        }

        private IPlayer Player
        {
            get {return InMemoryRepository.FindPlayer(view.Player.Id);}
        }
    }
}