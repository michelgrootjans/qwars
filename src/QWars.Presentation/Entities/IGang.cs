using System.Collections.Generic;

namespace QWars.Presentation.Entities
{
    public interface IGang
    {
        string Name { get; }
        int Money { get; }
        IEnumerable<IPlayer> Members { get; }
        ICollection<ITask> Tasks { get; }

        ITask CreateTask(string description, int difficulty, int reward, int xp);
        void IncreaseAllRewardsWith(double percent);
    }
}