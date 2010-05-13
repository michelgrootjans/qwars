using System;

namespace NHibernateDemo.Entities
{
    public abstract class Weapon
    {
        public virtual int Price { get; private set; }
        public virtual Player Owner { get; internal set; }

        protected Weapon(int price)
        {
            Price = price;
        }

        public virtual string Name
        {
            get { return GetType().Name; }
        }
    }

    public class Sword : Weapon
    {
        public Sword() : base(800)
        {
        }
    }

    public class Knife : Weapon
    {
        public Knife() : base(200)
        {
        }
    }

    internal class Gun : Weapon
    {
        public Gun() : base(1500)
        {
            NumberOfBullets = 0;
        }

        protected int NumberOfBullets { get; private set; }
    }
}