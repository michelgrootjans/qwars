namespace QWars.Entities
{
    public partial class Taser : Weapon
    {
        public override string Name
        {
            get
            {
                return "Taser";
            }
        }

        public override int SellPrice
        {
            get { return Price * 6 / 10; }
        }
    }
}
