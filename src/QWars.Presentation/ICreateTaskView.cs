namespace QWars.Presentation
{
    public interface ICreateTaskView
    {
        object PlayerId { get; }
        string Difficulty { get; }
        string Reward { get; }
        string XP { get; }
    }
}