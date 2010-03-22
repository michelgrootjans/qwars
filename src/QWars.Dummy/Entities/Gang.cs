using System.Collections.Generic;
using QWars.Presentation.Entities;

namespace QWars.Dummy.Entities
{
    public class Gang : IGang
    {
        public string Name { get; private set; }
        public int Money { get; set; }
        public IEnumerable<IPlayer> Members { get; set; }
        public ICollection<ITask> Tasks { get; private set; }

        public Gang(string name, string benefit)
        {
            Tasks = new List<ITask>();
            Members = new List<IPlayer>();
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public ITask CreateTask(string description, int difficulty, int reward, int xp)
        {
            var task = new Task(description, difficulty, reward, xp);
            Tasks.Add(task);
            return task;
        }

        public void IncreaseAllRewardsWith(double percent)
        {
            foreach (var task in Tasks)
                task.IncreaseRewardWith(percent);
        }
    }
}