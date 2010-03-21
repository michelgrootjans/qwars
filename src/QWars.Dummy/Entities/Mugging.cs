using System;
using QWars.Presentation.Entities;

namespace QWars.Dummy.Entities
{
    public class Mugging : ITask
    {
        private static readonly Random random = new Random();
        public int XP { get; private set; }
        public int Reward { get; private set; }

        public Mugging()
        {
            Reward = random.Next(0, 6);
            XP = random.Next(15, 20);
        }

        public int Difficulty
        {
            get { return 0; }
        }
    }
}