using System;
using QWars.Presentation.Entities;

namespace QWars.Presentation.Helpers
{
    public class TaskCalculator
    {
        private readonly IPlayer player;
        private readonly ITask task;
        private int moneyEarned;
        private int xpEarned;
        private static Random random = new Random();

        public TaskCalculator(IPlayer player, ITask task)
        {
            this.player = player;
            this.task = task;
            CalculateOutcome();
        }

        private void CalculateOutcome()
        {
            var attack = TenPercentUncertainty(player.XP);
            var defense = TenPercentUncertainty(task.Difficulty);
            if (attack > defense)
            {
                moneyEarned = task.Reward;
                xpEarned = task.XP;
            }
            else
            {
                moneyEarned = 0;
                xpEarned = -task.XP/2;
            }
        }

        private decimal TenPercentUncertainty(int value)
        {
            var percent = Convert.ToDecimal(random.Next(90, 110));
            return value*percent;

        }

        public int MoneyEarned
        {
            get {
                return moneyEarned;
            }
        }

        public int XpEarned
        {
            get {
                return xpEarned;
            }
        }
    }
}