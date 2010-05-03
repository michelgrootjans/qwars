using QWars.NHibernate.Entities;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Presenters
{
    public class NHBuyWeaponsPresenter : NHPresenter, IBuyWeaponsPresenter
    {
        private readonly IBuyWeaponsView view;

        public NHBuyWeaponsPresenter(IBuyWeaponsView view)
        {
            this.view = view;
        }

        public void BuyClub()
        {
            BuyWeapon(WeaponFactory.Club);
        }

        public void BuyKnife()
        {
            BuyWeapon(WeaponFactory.Knife);
        }

        public void BuyTaser()
        {
            BuyWeapon(WeaponFactory.Taser);
        }

        public void BuyGun()
        {
            BuyWeapon(WeaponFactory.Gun);
        }

        public void BuyBomb()
        {
            BuyWeapon(WeaponFactory.Bomb);
        }

        private void BuyWeapon(IWeapon weapon)
        {
            using(var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = session.Get<IPlayer>(view.Player.Id);
                player.Buy(weapon);
                transaction.Commit();
            }
        }
    }
}