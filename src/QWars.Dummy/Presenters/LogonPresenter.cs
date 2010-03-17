using QWars.Dummy.Entities;
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

        public IPlayerInfo LoginWithPlayerName(string playerName)
        {
            logger.Log(string.Format("{0} is logging in.", playerName));
            return new Player(playerName.Length, playerName);
        }
    }
}