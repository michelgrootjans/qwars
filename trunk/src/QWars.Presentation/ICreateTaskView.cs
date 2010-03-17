using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface ICreateTaskView
    {
        IPlayerInfo Player { get; }
        string Difficulty { get; }
        string Reward { get; }
        string XP { get; }
    }
}