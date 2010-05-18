namespace QWars.Entities
{
    public partial class Club : Weapon
    {
        public override string Name
        {
            get
            {
                return "Club";
            }
        }
        public override int SellPrice
        {
            get { return Price * 3 / 10; }
        }
        
    }
}
