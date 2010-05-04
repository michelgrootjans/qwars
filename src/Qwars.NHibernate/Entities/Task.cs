using System;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Entities
{
    public class Task : ITask
    {
        public virtual string Description { get; protected set; }
        public virtual int Difficulty { get; private set; }
        public virtual int Reward { get; private set; }
        public virtual int XP { get; private set; }

        protected Task()
        {
        }

        public Task(string description, int difficulty, int reward, int xp)
        {
            Description = description;
            Difficulty = difficulty;
            Reward = reward;
            XP = xp;
        }

        public virtual void IncreaseRewardWith(double bonus)
        {
            Reward = Convert.ToInt32((1 + bonus)*Reward);
        }
    }
}