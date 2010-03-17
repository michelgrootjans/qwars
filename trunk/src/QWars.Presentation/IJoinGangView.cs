using System.Collections;
using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface IJoinGangView
    {
        IPlayerInfo Player { get; }
        IGang SelectedGang { get; }

        IEnumerable Gangs { set; }
    }
}