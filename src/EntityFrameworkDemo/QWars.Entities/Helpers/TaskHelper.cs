using System;

namespace QWars.Entities.Helpers
{
    public class TaskCalculator
    {
        private readonly Player player;
        private readonly Task task;
        private int moneyEarned;
        private int xpEarned;
        private static Random random = new Random();
        private bool outCome;

        public TaskCalculator(Player player, Task task)
        {
            this.player = player;
            this.task = task;
            CalculateOutcome();
        }

        private void CalculateOutcome()
        {
            var attack = TenPercentUncertainty(player.XpWithWeaponBonus);
            var defense = TenPercentUncertainty(task.Difficulty);

            if (attack >= defense)
            {
                moneyEarned = task.Reward;
                xpEarned = task.XP;
                outCome = true;
            }
            else
            {
                moneyEarned = 0;
                xpEarned = -task.XP / 2;
                outCome = false;
            }

        }

        private decimal TenPercentUncertainty(int value)
        {
            var percent = Convert.ToDecimal(random.Next(90, 110));
            return value * percent;

        }

        public int MoneyEarned
        {
            get
            {
                return moneyEarned;
            }
        }

        public int XpEarned
        {
            get
            {
                return xpEarned;
            }
        }

        public bool OutCome
        {
            get
            {
                return outCome;
            }
        }
    }
}
