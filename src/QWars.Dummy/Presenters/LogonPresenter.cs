using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.Dummy.Presenters
{
    public class LogonPresenter : ILogonPresenter
    {
        private readonly Logger logger;

        public LogonPresenter()
        {
            logger = new Logger(this);
        }

        public PlayerInfo LoginWithPlayerName(string playerName)
        {
            logger.Log(string.Format("{0} is logging in.", playerName));
            var player = InMemoryRepository.Create(playerName);
            return new PlayerInfo(player.Id, player.Name); 
        }
    }
}