using System.Collections.Generic;

namespace QWars.Presentation.Entities
{
    public interface IBoss
    {
        IEnumerable<ITask> GetGangTasks();
        ITask CreateTask(string description, int difficulty, int reward, int xp);
        IGang CreateGang(string name, string bossBenefit);
        void IncreaseAllRewardsWith(double percent);
        IGang Gang { get; }
        string GangName { get; }
        int GangMoney { get; }
        IEnumerable<IPlayer> GangMembers { get; }
    }
}