﻿using System;
using System.Windows.Forms;
using QWars.NHibernate.Presenters;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.Win
{
    public partial class CreateGangView : Form, ICreateGangView
    {
        private readonly ICreateGangPresenter presenter;

        public CreateGangView()
        {
            InitializeComponent();
            presenter = new NHCreateGangPresenter(this);
        }

        private void CreateGangView_Load(object sender, EventArgs e)
        {
            presenter.Initialize();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            presenter.CreateGang();
            new BossView {Player = Player}.Show();
            Close();
        }

        public PlayerInfo Player { get; set; }

        public string GangName
        {
            get { return txtGangName.Text; }
        }

        public string BossBenefit
        {
            get { return txtBossBenefit.Text; }
        }
    }
}