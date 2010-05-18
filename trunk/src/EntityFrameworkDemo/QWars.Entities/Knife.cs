namespace QWars.Entities
{
    public partial class Knife : Weapon
    {
        public override string Name
        {
            get
            {
                return "Knife";
            }
        }

        public override int SellPrice
        {
            get { return Price * 5 / 10; }
        }
    }
}
