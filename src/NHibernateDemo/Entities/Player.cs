using System;
using Iesi.Collections.Generic;

namespace NHibernateDemo.Entities
{
    public class Player
    {
        public Player()
        {
            Weapons = new HashedSet<Weapon>();
        }

        public string Name { get; set; }
        public int Money { get; set; }

        public ISet<Weapon> Weapons { get; set; }


        public void Buy(Weapon weapon)
        {
            Weapons.Add(weapon);
            Money -= weapon.Price;
        }
    }
}