using QWars.Presentation.Entities;

namespace QWars.NHibernate.Entities
{
    public class Mugging : ITask
    {
        public int Difficulty
        {
            get { return 0; }
        }

        public int Reward
        {
            get { return 10; }
        }

        public int XP
        {
            get { return 10; }
        }

        public void IncreaseRewardWith(double bonus)
        {
            // do nothing
        }
    }
}