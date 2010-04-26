using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface ILogonPresenter
    {
        PlayerInfo LoginWithPlayerName(string playerName);
    }
}