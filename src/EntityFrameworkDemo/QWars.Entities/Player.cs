using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using QWars.Entities.Helpers;

namespace QWars.Entities
{
    public partial class Player : INotifyPropertyChanged
    {
        #region Primitive Properties

        private int _id;
        public virtual int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Id"));
            }
        }

        private string _name;
        public virtual string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        private int _money;
        public virtual int Money
        {
            get { return _money; }
            set
            {
                _money = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Money"));
            }
        }

        private int _xp;
        public virtual int XP
        {
            get { return _xp; }
            set
            {
                _xp = value;
                PropertyChanged(this, new PropertyChangedEventArgs("XP"));
            }
        }

        #endregion

        #region Navigation Properties

        public virtual Gang MemberOf
        {
            get { return _memberOf; }
            set
            {
                if (!ReferenceEquals(_memberOf, value))
                {
                    _memberOf = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("MemberOf"));
                }
            }
        }
        private Gang _memberOf;

        public virtual Gang OwnerOf
        {
            get { return _ownerOf; }
            set
            {
                if (!ReferenceEquals(_ownerOf, value))
                {
                    _ownerOf = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("OwnerOf"));
                }
            }
        }
        private Gang _ownerOf;

        public virtual ObservableCollection<Task> ExecutedTasks
        {
            get
            {
                return _executedTasks;
            }
            set
            {
                if (!ReferenceEquals(_executedTasks, value))
                {
                    _executedTasks = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ExecutedTasks")); 
                }
            }
        }
        private ObservableCollection<Task> _executedTasks;

        public virtual ObservableCollection<Weapon> Weapons
        {
            get
            {
                return _weapons;
            }
            set
            {
                if (!ReferenceEquals(_weapons, value))
                {
                    _weapons = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Weapons")); 
                }
            }
        }
        private ObservableCollection<Weapon> _weapons;

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged = delegate {};

        #endregion

        public int XpWithWeaponBonus
        {
            get { return XP + XpBonus; }
        }

        public int XpBonus
        {
            get
            {
                if (Weapons == null || Weapons.Count() == 0) 
                    return 0;
                return Convert.ToInt32(XP * BestWeapon.XpBonus);
            }
        }

        private Weapon BestWeapon
        {
            get
            {
                return Weapons != null 
                    ? Weapons.OrderByDescending(w => w.XpBonus).FirstOrDefault()
                    : null;
            }
        }

        public void ExecuteTask(Task task)
        {
            var calculator = new TaskCalculator(this, task);
            Money += calculator.MoneyEarned;
            XP += calculator.XpEarned;
            task.ExecutedBy = this;
            task.Outcome = calculator.OutCome; 
        }

        public void BuyWeapon(Weapon weapon)
        {
            if (weapon != null)
            {
                Money -= weapon.Price;
                Weapons.Add(weapon);
            }
        }

        public void SellUselessWeapons()
        {
            if (Weapons == null) return;

            foreach (var weapon in Weapons.Where(w => !w.Equals(BestWeapon)).ToList())
            {
                Weapons.Remove(weapon);
                Money += weapon.SellPrice;
            }
        }
    }
}
