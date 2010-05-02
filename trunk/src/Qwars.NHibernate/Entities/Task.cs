using System;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Entities
{
    public class Task : ITask
    {
        public int Difficulty { get; private set; }
        public int Reward { get; private set; }
        public int XP { get; private set; }

        public Task(string description, int difficulty, int reward, int xp)
        {
            Difficulty = difficulty;
            Reward = reward;
            XP = xp;
        }
        
        public void IncreaseRewardWith(double bonus)
        {
            Reward = Convert.ToInt32((1 + bonus) * Reward);
        }
    }
}