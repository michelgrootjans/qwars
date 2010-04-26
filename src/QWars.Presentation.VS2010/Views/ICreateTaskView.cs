using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface ICreateTaskView
    {
        PlayerInfo Player { get; }
        string Description { get; }
        int Difficulty { get; }
        int Reward { get; }
        int XP { get; }
    }
}