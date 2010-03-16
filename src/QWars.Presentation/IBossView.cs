using System.Collections;

namespace QWars.Presentation
{
    public interface IBossView
    {
        object PlayerId { get; }

        string GangName { set; }
        int GangMoney { set; }
        IEnumerable Members { set;  }
        int NumberOfMembers {  set; }
        IEnumerable Tasks { set; }
    }
}