using System.Windows.Forms;
using QWars.Dummy;
using QWars.Presentation;

namespace QWars.Win
{
    public partial class PlayerView : Form, IPlayerView
    {
        private readonly IPlayerPresenter presenter;

        public PlayerView()
        {
            InitializeComponent();
            presenter = new PlayerPresenter(this);
        }

        public object PlayerId { get; set; }

        private void PlayerView_Load(object sender, System.EventArgs e)
        {
            presenter.Initialize();
        }

        private void btnMug_Click(object sender, System.EventArgs e)
        {
            presenter.MugPedestrian();
        }

        private void btnSellUnusedWeapons_Click(object sender, System.EventArgs e)
        {
            presenter.SellUnusedWeapons();
        }

        private void btnBuyWeapon_Click(object sender, System.EventArgs e)
        {
            var view = new BuyWeaponsView();
            view.Show();
        }

        private void btnJoinGang_Click(object sender, System.EventArgs e)
        {
            var view = new JoinGangView();
            view.Show();
        }

        private void btnCreateGang_Click(object sender, System.EventArgs e)
        {
            var view = new CreateGangView();
            view.Show();
        }

        private void btnLeaveGang_Click(object sender, System.EventArgs e)
        {
            presenter.LeaveGang();
        }

        private void btnDisbandGang_Click(object sender, System.EventArgs e)
        {
            presenter.DisbandGang();
        }
    }
}