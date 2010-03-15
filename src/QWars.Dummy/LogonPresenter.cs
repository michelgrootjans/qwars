using QWars.Presentation;

namespace QWars.Dummy
{
    public class LogonPresenter : Presenter, ILogonPresenter
    {
        public object LoginWithPlayerName(string playerName)
        {
            Log(string.Format("{0} is logging in.", playerName));
            return 25;
        }
    }
}