using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QWars.Presentation.Entities;

namespace QWars.EF.Entities
{
    public partial class Task : ITask
    {
        public virtual int Id
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual int Difficulty
        {
            get;
            set;
        }

        public virtual int Reward
        {
            get;
            set;
        }

        public virtual int XP
        {
            get;
            set;
        }

        public virtual IGang Gang
        {
            get;
            set;
        }

        public virtual IPlayer ExecutedByPlayer { get; set; }

        public void IncreaseRewardWith(double bonus)
        {
            Reward = Convert.ToInt32((1 + bonus) * Reward);
        }
    }
}
