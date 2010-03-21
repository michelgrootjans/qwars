namespace QWars.Presentation.Entities
{
    public interface IWeapon
    {
        string Name { get; }
        double XpBonus { get; }
        int Price { get; }
        int SellPrice { get; }
    }
}