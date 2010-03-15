using QWars.Presentation;

namespace QWars.Dummy
{
    public class PlayerPresenter : Presenter, IPlayerPresenter
    {
        private readonly IPlayerView view;
        private int money;
        private int xp;

        public PlayerPresenter(IPlayerView view)
        {
            Log("Constructor");
            this.view = view;
            money = 0;
            xp = 0;
        }

        public void Initialize()
        {
            Log("Initialize");
            UpdateView();
        }

        public void MugPedestrian()
        {
            Log("MugPedestrian");
            xp += 100;
            money += 20;
            UpdateView();
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

        private void UpdateView()
        {
            view.PlayerName = "Armageddon";
            view.Money = money;
            view.XP = xp;
        }
    }
}