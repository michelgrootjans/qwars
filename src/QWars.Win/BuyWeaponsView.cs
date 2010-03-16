using System;
using System.Windows.Forms;
using QWars.Dummy.Presenters;
using QWars.Presentation;

namespace QWars.Win
{
    public partial class BuyWeaponsView : Form, IBuyWeaponsView
    {
        private readonly IBuyWeaponsPresenter presenter;

        public BuyWeaponsView()
        {
            InitializeComponent();
            presenter = new BuyWeaponsPresenter(this);
        }

        public object PlayerId { get; set; }

        private void btnBuyClub_Click(object sender, EventArgs e)
        {
            presenter.BuyClub();
        }

        private void btnBuyKnife_Click(object sender, EventArgs e)
        {
            presenter.BuyKnife();
        }

        private void btnBuyTaser_Click(object sender, EventArgs e)
        {
            presenter.BuyTaser();
        }

        private void btnBuyGun_Click(object sender, EventArgs e)
        {
            presenter.BuyGun();
        }

        private void btnBuyBomb_Click(object sender, EventArgs e)
        {
            presenter.BuyBomb();
        }
    }
}