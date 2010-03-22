namespace QWars.Presentation.Entities
{
    public interface ITask
    {
        int Difficulty { get; }
        int Reward { get; }
        int XP { get; }
        void IncreaseRewardWith(double bonus);
    }
}