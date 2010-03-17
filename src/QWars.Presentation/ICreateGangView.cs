using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface ICreateGangView
    {
        IPlayerInfo Player { get; }
        string GangName { get; }
        string BossBenefit { get; }
    }
}