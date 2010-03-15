using QWars.Presentation;

namespace QWars.Dummy
{
    public class PlayerPresenter : Presenter, IPlayerPresenter
    {
        private readonly IPlayerView view;

        public PlayerPresenter(IPlayerView view)
        {
            Log("Constructor");
            this.view = view;
        }

        public void Initialize()
        {
            Log("Initialize");
        }

        public void MugPedestrian()
        {
            Log("MugPedestrian");
        }

        public void SellUnusedWeapons()
        {
            Log("SellUnusedWeapons");
        }

        public void LeaveGang()
        {
            Log("LeaveGang");
        }

        public void DisbandGang()
        {
            Log("DisbandGang");
        }
    }
}