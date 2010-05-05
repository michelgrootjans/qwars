using System.Collections.Generic;
using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface IPlayerView
    {
        PlayerInfo Player { get; }

        string Title { set; }
        int Money { set; }
        string XP { set; }
        IEnumerable<IWeapon> Weapons { set; }
        bool IsBoss { set; }
        bool IsMember { set; }
    }
}