using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using QWars.Presentation.Entities;
using QWars.Presentation.Helpers;

namespace QWars.EF.Entities
{
    public partial class Player : IPlayer, IBoss
    {
        public virtual int Id
        {
            get;
            set;
        }
        public virtual string Name
        {
            get;
            private set;
        }
        public virtual int Money
        {
            get;
            private set;
        }
        public virtual int XP
        {
            get;
            private set;
        }

        private ISet<IWeapon> _weapons;
        public virtual IEnumerable<IWeapon> Weapons
        {
            get
            {
                return _weapons;
            }
            set
            {
                _weapons = new HashSet<IWeapon>(value);
            }
        }
        
        public virtual IGang OwnedGang { get; set; }
        public virtual IGang JoinedGang { get; set; }

        private ISet<ITask> _tasks;
        public virtual IEnumerable<ITask> Tasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                _tasks = new HashSet<ITask>(value);
            }
        }


        public int XPWithWeaponBonus
        {
            get { return XP + XPBonus; }
        }

        public int XPBonus
        {
            get
            {
                if (Weapons.Count() == 0) return 0;
                return Convert.ToInt32(XP * BestWeapon.XpBonus);
            }
        }

        private IWeapon BestWeapon
        {
            get { return Weapons.OrderByDescending(w => w.XpBonus).First(); }
        }

        public void Buy(IWeapon weapon)
        {
            _weapons.Add(weapon);
        }

        public void SellUnusedWeapons()
        {
            if (Weapons.Count() == 0) return;

            foreach (var weapon in Weapons.Where(w => !w.Equals(BestWeapon)).ToList())
                Sell(weapon);
        }

        private void Sell(IWeapon weapon)
        {
            _weapons.Remove(weapon);
        }

        public void Execute(ITask task)
        {
            var calculator = new TaskCalculator(this, task);
            Money += calculator.MoneyEarned;
            XP += calculator.XpEarned;
        }

        public void Join(IGang gang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITask> GetGangTasks()
        {
            throw new NotImplementedException();
        }

        public ITask CreateTask(string description, int difficulty, int reward, int xp)
        {
            throw new NotImplementedException();
        }

        public IGang CreateGang(string name, string bossBenefit)
        {
            throw new NotImplementedException();
        }

        public void IncreaseAllRewardsWith(double percent)
        {
            throw new NotImplementedException();
        }

        public IGang Gang
        {
            get { return OwnedGang; }
        }

        public string GangName
        {
            get { return OwnedGang.Name; }
        }

        public int GangMoney
        {
            get { return OwnedGang.Money; }
        }

        public IEnumerable<IPlayer> GangMembers
        {
            get { return OwnedGang.Members; }
        }
    }
}
