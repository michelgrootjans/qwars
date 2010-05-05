using System;
using System.Collections.Generic;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Entities
{
    internal class NullGang : IGang
    {
        public string Name
        {
            get { return ""; }
        }

        public int Money
        {
            get { return 0; }
        }

        public IEnumerable<IPlayer> Members
        {
            get { return new List<IPlayer>(); }
        }

        public ICollection<ITask> Tasks
        {
            get { return new List<ITask>(); }
        }

        public ITask CreateTask(string description, int difficulty, int reward, int xp)
        {
            throw new NotImplementedException();
        }

        public void IncreaseAllRewardsWith(double percent)
        {
            throw new NotImplementedException();
        }

        public void AddMember(IPlayer member)
        {
            throw new NotImplementedException();
        }
    }
}