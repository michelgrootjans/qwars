using System.Collections.Generic;
using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface IBossView
    {
        PlayerInfo Player { get; }

        string GangName { set; }
        int GangMoney { set; }
        IEnumerable<IPlayer> Members { set; }
        int NumberOfMembers { set; }
        IEnumerable<ITask> Tasks { set; }
    }
}