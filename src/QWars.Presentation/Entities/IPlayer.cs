using System.Collections.Generic;

namespace QWars.Presentation.Entities
{
    public interface IPlayer
    {
        string Name { get; }
        IEnumerable<IWeapon> Weapons { get; }
        int Money { get; }
        int XP { get; }
        int XPWithWeaponBonus { get; }
        int XPBonus { get; }
        bool IsBoss { get; }
        bool IsMember { get; }
        IEnumerable<ITask> GetGangTasks();

        void Buy(IWeapon weapon);
        void SellUnusedWeapons();
        void Execute(ITask task);
        void Join(IGang gang);
    }
}