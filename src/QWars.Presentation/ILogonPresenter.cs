using QWars.Presentation.Entities;

namespace QWars.Presentation
{
    public interface ILogonPresenter
    {
        IPlayerInfo LoginWithPlayerName(string playerName);
    }
}