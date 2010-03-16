using QWars.Presentation;

namespace QWars.Dummy.Presenters
{
    public class LogonPresenter : ILogonPresenter
    {
        private readonly Logger logger;

        public LogonPresenter()
        {
            logger = new Logger(this);
        }

        public object LoginWithPlayerName(string playerName)
        {
            logger.Log(string.Format("{0} is logging in.", playerName));
            return playerName.Length;
        }
    }
}