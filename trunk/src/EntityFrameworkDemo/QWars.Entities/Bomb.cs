namespace QWars.Entities
{
    public partial class Bomb : Weapon
    {
        public override string Name
        {
            get
            {
                return "Bomb";
            }
        }

        public override int SellPrice
        {
            get { return Price * 8 / 10; }
        }
    }
}
