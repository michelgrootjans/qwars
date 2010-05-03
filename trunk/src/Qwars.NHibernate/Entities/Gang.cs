using System;
using System.Collections.Generic;
using Iesi.Collections.Generic;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Entities
{
    public class Gang    : IGang
    {
        public virtual IPlayer Boss { get; private set; }
        public virtual string Name { get; private set; }
        public virtual int Money { get; private set; }
        private ICollection<IPlayer> members;
        public virtual IEnumerable<IPlayer> Members
        {
            get { return members; }
        }

        public virtual ICollection<ITask> Tasks { get; private set; }


        protected Gang()
        {
            members = new HashedSet<IPlayer>();
            Tasks = new HashedSet<ITask>();
        }

        public Gang(IPlayer boss, string gangName) : this()
        {
            Boss = boss;
            Name = gangName;
            Money = 0;
        }

        public virtual ITask CreateTask(string description, int difficulty, int reward, int xp)
        {
            throw new NotImplementedException();
        }

        public virtual void IncreaseAllRewardsWith(double percent)
        {
            throw new NotImplementedException();
        }

        public virtual void AddMember(IPlayer member)
        {
            members.Add(member);
        }
    }
}