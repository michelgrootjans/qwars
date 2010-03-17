using System.Collections.Generic;
using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface IPlayerView
    {
        PlayerInfo Player { get; }

        string PlayerName { set; }
        int Money { set; }
        int XP { set; }
        IEnumerable<IWeapon> Weapons { set; }
    }
}