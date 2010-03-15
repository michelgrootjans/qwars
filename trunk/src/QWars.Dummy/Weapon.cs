namespace QWars.Dummy
{
    internal class Weapon
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
    }
}