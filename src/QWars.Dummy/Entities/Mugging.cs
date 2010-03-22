using System;

namespace QWars.Dummy.Entities
{
    public class Mugging : Task
    {
        private static readonly Random random = new Random();

        public Mugging() : base("Mugging", 0, random.Next(0, 6), random.Next(15, 20))
        {
        }
    }
}