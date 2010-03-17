using QWars.Presentation.Entities;

namespace QWars.Dummy.Entities
{
    internal class Weapon : IWeapon
    {
        private readonly string name;
        private readonly double xpBonus;

        public Weapon(string name, double xpBonus)
        {
            this.name = name;
            this.xpBonus = xpBonus;
        }

        public double XpBonus
        {
            get { return xpBonus; }
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