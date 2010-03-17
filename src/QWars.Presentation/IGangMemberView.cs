using System.Collections;

namespace QWars.Presentation
{
    public interface IGangMemberView
    {
        object PlayerId { get; }
        object SelectedTask { get; }
        IEnumerable Tasks { set; }
    }
}