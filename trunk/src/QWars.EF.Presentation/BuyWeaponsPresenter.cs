using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using QWars.EF.DataModel;
using QWars.EF.Entities;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.EF.Presentation
{
    public class BuyWeaponsPresenter : PresenterBase, IBuyWeaponsPresenter
    {
        private int _playerId;
        public int PlayerId
        {
            get { return _playerId; }
            set
            {
                _playerId = value;
                NotifyPropertyChanged("PlayerId");
            }
        }

        private IWeapon _weaponToBuy;
        public IWeapon WeaponToBuy
        {
            get { return _weaponToBuy; }
            set
            {
                _weaponToBuy = value;
                NotifyPropertyChanged("WeaponToBuy");
            }
        }

        #region IBuyWeaponsPresenter Members

        public void BuyClub()
        {
            BuyWeapon(WeaponToBuy);
        }

        public void BuyKnife()
        {
            BuyWeapon(WeaponToBuy);
        }

        public void BuyTaser()
        {
            BuyWeapon(WeaponToBuy);
        }

        public void BuyGun()
        {
            BuyWeapon(WeaponToBuy);
        }

        public void BuyBomb()
        {
            BuyWeapon(WeaponToBuy);
        }

        private void BuyWeapon<T>(T weapon) where T:IWeapon
        {
            using (var context = new QWarsContext())
            using (var transaction = context.Connection.BeginTransaction())
            {
                var player = context.Players.Where(p => p.Id == PlayerId).SingleOrDefault();
                player.Buy(weapon);
                transaction.Commit();
            }
        }
        #endregion
    }
}
