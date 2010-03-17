using System.Collections;

namespace QWars.Presentation
{
    public interface IJoinGangView
    {
        object PlayerId { get; }
        object SelectedGang { get; }

        IEnumerable Gangs { set; }
    }
}