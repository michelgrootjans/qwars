using System.Collections.Generic;
using QWars.Presentation.Entities;

namespace QWars.Dummy.Entities
{
    public class Gang : IGang
    {
        public string Name { get; private set; }
        public int Money { get; set; }
        private ICollection<IPlayer> members;

        public ICollection<ITask> Tasks { get; private set; }

        protected Gang()
        {
        }

        public Gang(string name, string benefit)
        {
            Tasks = new List<ITask>();
            members = new List<IPlayer>();
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual ITask CreateTask(string description, int difficulty, int reward, int xp)
        {
            var task = new Task(description, difficulty, reward, xp);
            Tasks.Add(task);
            return task;
        }

        public virtual IEnumerable<IPlayer> Members
        {
            get { return members; }
        }

        public virtual void IncreaseAllRewardsWith(double percent)
        {
            foreach (var task in Tasks)
                task.IncreaseRewardWith(percent);
        }

        public virtual void AddMember(IPlayer member)
        {
            members.Add(member);
        }
    }
}