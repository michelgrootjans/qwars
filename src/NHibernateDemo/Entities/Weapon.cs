namespace NHibernateDemo.Entities
{
    public abstract class Weapon
    {
        public int Price { get; private set; }

        protected Weapon()
        {
        }

        protected Weapon(int price)
        {
            Price = price;
        }

        public string Name
        {
            get { return GetType().Name; }
        }
    }

    internal class Gun : Weapon
    {
        public Gun() : base(1500)
        {
        }
    }
}