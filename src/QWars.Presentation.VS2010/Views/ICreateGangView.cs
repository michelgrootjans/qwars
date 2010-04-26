using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface ICreateGangView
    {
        PlayerInfo Player { get; }
        string GangName { get; }
        string BossBenefit { get; }
    }
}