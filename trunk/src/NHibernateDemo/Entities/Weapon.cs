namespace NHibernateDemo.Entities
{
    public class Weapon
    {
        protected Weapon()
        {
        }

        public Weapon(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public int Price { get; set; }
    }
}