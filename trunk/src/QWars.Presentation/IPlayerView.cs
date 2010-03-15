using System.Collections.Generic;

namespace QWars.Presentation
{
    public interface IPlayerView
    {
        string PlayerName { set; }
        int Money { set; }
        int XP { set; }
        IEnumerable<object> Weapons { set; }
        object PlayerId { get; }
    }
}