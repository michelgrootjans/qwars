using Iesi.Collections.Generic;

namespace NHibernateDemo.Entities
{
    public class Player
    {
        public Player()
        {
            Weapons = new HashedSet<Weapon>();
        }

        public virtual string Name { get; set; }
        public virtual int Money { get; set; }
        public virtual ISet<Weapon> Weapons { get; set; }

        public virtual void Buy(Weapon weapon)
        {
            Weapons.Add(weapon);
            Money -= weapon.Price;
        }
    }
}