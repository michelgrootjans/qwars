using System.Collections;
using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface IGangMemberView
    {
        PlayerInfo Player { get; }
        ITask SelectedTask { get; }
        IEnumerable Tasks { set; }
    }
}