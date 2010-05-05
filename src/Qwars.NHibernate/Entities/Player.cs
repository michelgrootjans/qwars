using System;
using System.Collections.Generic;
using System.Linq;
using Iesi.Collections.Generic;
using QWars.Presentation.Entities;
using QWars.Presentation.Helpers;

namespace QWars.NHibernate.Entities
{
    public class Player : IPlayer, IBoss
    {
        private readonly ISet<IWeapon> weapons;
        private IGang memberOf;
        private IGang ownedGang;
        public virtual string Name { get; private set; }
        public virtual int Money { get; private set; }
        public virtual int XP { get; private set; }

        protected Player()
        {
            weapons = new HashedSet<IWeapon>();
        }

        public Player(string name) : this()
        {
            Name = name;
            Money = 0;
            XP = 0;
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
                return Convert.ToInt32(XP*BestWepon.XpBonus);
            }
        }

        public bool IsBoss
        {
            get { return ownedGang != null; }
        }

        public bool IsMember
        {
            get { return memberOf != null; }
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
            get { return weapons == null ? null : weapons.OrderByDescending(w => w.XpBonus).First(); }
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

        private IGang Gang
        {
            get { return ownedGang ?? memberOf ?? new NullGang(); }
        }

        public virtual IEnumerable<ITask> GetGangTasks()
        {
            return Gang.Tasks;
        }

        public virtual IGang CreateGang(string name, string bossBenefit)
        {
            ownedGang = new Gang(this, name);
            return ownedGang;
        }

        public virtual ITask CreateTask(string description, int difficulty, int reward, int xp)
        {
            return ownedGang.CreateTask(description, difficulty, reward, XP);
        }

        public virtual void IncreaseAllRewardsWith(double percent)
        {
            ownedGang.IncreaseAllRewardsWith(percent);
        }

        public virtual string GangName
        {
            get { return Gang.Name; }
        }

        public virtual int GangMoney
        {
            get { return Gang.Money; }
        }

        public virtual IEnumerable<IPlayer> GangMembers
        {
            get { return Gang.Members; }
        }
    }
}