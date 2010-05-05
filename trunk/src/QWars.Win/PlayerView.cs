using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QWars.NHibernate.Presenters;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.Win
{
    public partial class PlayerView : Form, IPlayerView
    {
        private readonly IPlayerPresenter presenter;
        private bool isBoss;
        private bool isMember;

        public PlayerView()
        {
            InitializeComponent();
            presenter = new NHPlayerPresenter(this);
        }

        public PlayerInfo Player { get; set; }

        private void PlayerView_Load(object sender, EventArgs e)
        {
            presenter.Initialize();
        }

        private void btnMug_Click(object sender, EventArgs e)
        {
            presenter.MugPedestrian();
        }

        private void btnSellUnusedWeapons_Click(object sender, EventArgs e)
        {
            presenter.SellUnusedWeapons();
        }

        private void btnBuyWeapon_Click(object sender, EventArgs e)
        {
            var view = new BuyWeaponsView {Player = Player};
            view.ShowDialog();
            presenter.UpdateView();
        }

        private void btnJoinGang_Click(object sender, EventArgs e)
        {
            var view = new JoinGangView {Player = Player};
            view.Show();
        }

        private void btnCreateGang_Click(object sender, EventArgs e)
        {
            var view = new CreateGangView {Player = Player};
            view.Show();
        }

        private void btnViewGang_Click(object sender, EventArgs e)
        {
            var view = isBoss
                           ? (Form) new BossView {Player = Player}
                           : new GangMemberView {Player = Player};
            view.Show();
        }


        public bool IsBoss
        {
            set
            {
                isBoss = value;
                UpdateButtons();
            }
        }


        public bool IsMember
        {
            set
            {
                isMember = value;
                UpdateButtons();
            }
        }

        private void UpdateButtons()
        {
            var showGoToGangButton = isMember || isBoss;
            btnViewGang.Enabled = showGoToGangButton;
            btnCreateGang.Enabled = !showGoToGangButton;
            btnJoinGang.Enabled = !showGoToGangButton;
        }

        public string Title
        {
            set { Text = "Player: " + value; }
        }

        public int Money
        {
            set { lblMoney.Text = value.ToString(); }
        }

        public string XP
        {
            set { lblExperience.Text = value; }
        }

        public IEnumerable<IWeapon> Weapons
        {
            set { lstWeapons.DataSource = value; }
        }
    }
}