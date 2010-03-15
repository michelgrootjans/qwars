using System;
using QWars.Presentation;

namespace QWars.Dummy
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
            logger.Log(string.Format("Player {0} buys a new club", PlayerId));
        }

        public void BuyKnife()
        {
            logger.Log(string.Format("Player {0} buys a new knife", PlayerId));
        }

        public void BuyTaser()
        {
            logger.Log(string.Format("Player {0} buys a new taser", PlayerId));
        }

        public void BuyGun()
        {
            logger.Log(string.Format("Player {0} buys a new gun", PlayerId));
        }

        public void BuyBomb()
        {
            logger.Log(string.Format("Player {0} buys a new bomb", PlayerId));
        }

        private object PlayerId
        {
            get { return view.PlayerId; }
        }
    }
}