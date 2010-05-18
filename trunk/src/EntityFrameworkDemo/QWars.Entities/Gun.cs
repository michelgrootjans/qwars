namespace QWars.Entities
{
    public partial class Gun : Weapon
    {
        public override string Name
        {
            get
            {
                return "Gun";
            }
        }
        public override int SellPrice
        {
            get { return Price * 7 / 10; }
        }
    }
}
