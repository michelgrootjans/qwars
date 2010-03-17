using System.Collections;
using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface IGangMemberView
    {
        PlayerInfo PlayerId { get; }
        ITask SelectedTask { get; }
        IEnumerable Tasks { set; }
    }
}