using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface ICreateTaskView
    {
        PlayerInfo Player { get; }
        string Difficulty { get; }
        string Reward { get; }
        string XP { get; }
    }
}