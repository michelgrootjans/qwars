using System;
using QWars.Presentation.Entities;

namespace QWars.Dummy.Entities
{
    public class Task : ITask
    {
        public string Description { get; protected set; }
        public int Difficulty { get; protected set; }
        public int Reward { get; protected set; }
        public int XP { get; protected set; }

        public void IncreaseRewardWith(double bonus)
        {
            Reward = Convert.ToInt32((1 + bonus) * Reward);
        }

        public Task(string description, int difficulty, int reward, int xp)
        {
            Description = description;
            Difficulty = difficulty;
            Reward = reward;
            XP = xp;
        }
    }
}