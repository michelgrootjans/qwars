using System;
using System.Collections.Generic;
using System.Linq;
using Iesi.Collections.Generic;
using QWars.Presentation.Entities;
using QWars.Presentation.Helpers;

namespace QWars.NHibernate.Entities
{
    public class Player : IPlayer
    {
        private ISet<IWeapon> weapons;
        private IGang memberOf;
        public virtual string Name { get; private set; }
        public virtual int Money { get; private set; }
        public virtual int XP { get; private set; }

        protected Player()
        {
        }

        public Player(string name)
        {
            Name = name;
            Money = 0;
            XP = 0;
            weapons = new HashedSet<IWeapon>();
        }

        public virtual IEnumerable<IWeapon> Weapons
        {
            get { return weapons; }
        }

        public virtual int XPWithWeaponBonus
        {
            get { return XP + XPBonus; }
        }

        public virtual int XPBonus
        {
            get
            {
                if (weapons.Count() == 0) return 0;
                return Convert.ToInt32(XP * BestWepon.XpBonus);
            }
        }

        public virtual void Buy(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public virtual void SellUnusedWeapons()
        {
            if (weapons.Count() == 0) return;

            foreach (var weapon in weapons.Where(w => !w.Equals(BestWepon)).ToList())
                Sell(weapon);
        }

        private IWeapon BestWepon
        {
            get
            {
                return weapons == null ? null : weapons.OrderByDescending(w => w.XpBonus).First();
            }
        }

        private void Sell(IWeapon weapon)
        {
            weapons.Remove(weapon);
        }

        public virtual void Execute(ITask task)
        {
            var calculator = new TaskCalculator(this, task);
            Money += calculator.MoneyEarned;
            XP += calculator.XpEarned;
        }

        public virtual void Join(IGang gang)
        {
            memberOf = gang;
            gang.AddMember(this);
        }
    }
}