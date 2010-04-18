using QWars.Presentation.Entities;

namespace QWars.NHibernate.Entities
{
    public class Weapon : IWeapon
    {
        protected Weapon()
        {
        }

        internal Weapon(string name, int price, double xpBonus)
        {
            Name = name;
            XpBonus = xpBonus;
            Price = price;
        }

        public virtual string Name { get; private set; }

        public virtual double XpBonus { get; private set; }

        public virtual int Price { get; private set; }

        public virtual int SellPrice
        {
            get { return Price*6/10; }
        }
    }
}