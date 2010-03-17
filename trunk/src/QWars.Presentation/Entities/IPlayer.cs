using System.Collections.Generic;

namespace QWars.Presentation.Entities
{
    public interface IPlayer
    {
        IEnumerable<IWeapon> Weapons { get; }
        int Money { get; }
        int XP { get; }

        void AddXp(int xp);
        void AddMoney(int amount);
        void Buy(IWeapon weapon);
    }
}