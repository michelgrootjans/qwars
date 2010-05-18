namespace QWars.Entities
{
    public class Mugging : Task
    {
        public override int Difficulty
        {
            get { return 2; }
        }

        public override int Reward
        {
            get { return 10; }
        }

        public override int XP
        {
            get { return 10; }
        }
    }
}
