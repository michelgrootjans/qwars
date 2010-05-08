namespace NHibernateDemo.Entities
{
    public abstract class Weapon
    {
        public int Price { get; private set; }

        protected Weapon()
        {
        }

        public Weapon(int price)
        {
            Price = price;
        }

    }

    class Gun : Weapon
    {
        public Gun() : base(1500)
        {
        }
    }
}