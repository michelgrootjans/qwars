using QWars.Dummy.Entities;
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
            logger.Log(string.Format("Player {0} buys a new club", Player));
            Player.Buy(new Weapon("Club", 1.05));
        }

        public void BuyKnife()
        {
            logger.Log(string.Format("Player {0} buys a new knife", Player));
        }

        public void BuyTaser()
        {
            logger.Log(string.Format("Player {0} buys a new taser", Player));
        }

        public void BuyGun()
        {
            logger.Log(string.Format("Player {0} buys a new gun", Player));
        }

        public void BuyBomb()
        {
            logger.Log(string.Format("Player {0} buys a new bomb", Player));
        }

        private IPlayer Player
        {
            get
            {
                //get the player from the db
                //here we just cast the player from the view
                return view.Player as IPlayer;
            }
        }
    }
}