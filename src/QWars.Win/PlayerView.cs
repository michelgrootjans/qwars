﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QWars.Dummy.Presenters;
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
            var view = new BuyWeaponsView{PlayerId = PlayerId};
            view.Show();
        }

        private void btnJoinGang_Click(object sender, EventArgs e)
        {
            var view = new JoinGangView();
            view.Show();
        }

        private void btnCreateGang_Click(object sender, EventArgs e)
        {
            var view = new CreateGangView{PlayerId = PlayerId};
            view.Show();
        }

        public string PlayerName
        {
            set { Text = "Player: " + value; }
        }

        public int Money
        {
            set { lblMoney.Text = value.ToString(); }
        }

        public int XP
        {
            set { lblExperience.Text = value.ToString(); }
        }

        public IEnumerable<object> Weapons
        {
            set { lstWeapons.DataSource = value; }
        }
    }
}