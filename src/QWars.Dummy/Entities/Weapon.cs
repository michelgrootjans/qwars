using System;
using QWars.Presentation.Entities;

namespace QWars.Dummy.Entities
{
    internal class Weapon : IWeapon
    {
        private readonly string name;
        private readonly double xpBonus;
        private readonly int price;

        public Weapon(string name, int price, double xpBonus)
        {
            this.name = name;
            this.price = price;
            this.xpBonus = xpBonus;
        }

        public double XpBonus
        {
            get { return xpBonus; }
        }

        public int Price
        {
            get { return price; }
        }

        public int SellPrice
        {
            get { return price/2; }
        }

        public string Name
        {
            get { return name; }
        }

        public override string ToString()
        {
            return string.Format("{0} (+{1})", Name, xpBonus);
        }
    }
}