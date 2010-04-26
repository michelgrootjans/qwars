using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using QWars.Presentation.Entities;

namespace QWars.EF.Entities
{
    public partial class Gang : IGang
    {
        public virtual int Id
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            private set;
        }

        public virtual int Money
        {
            get;
            private set;
        }

        public virtual IBoss Boss { get; set; }
        
        private ISet<IPlayer> _members;
        public virtual IEnumerable<IPlayer> Members
        {
            get
            {
                return _members;
            }
            set
            {
                _members = new HashSet<IPlayer>(value);
            }
        }

        private ISet<ITask> _tasks;
        public virtual IEnumerable<ITask> Tasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                _tasks = new HashSet<ITask>(value);
            }
        }
        
        public ITask CreateTask(string description, int difficulty, int reward, int xp)
        {
            throw new NotImplementedException();
        }

        public void IncreaseAllRewardsWith(double percent)
        {
            throw new NotImplementedException();
        }
    }
}
