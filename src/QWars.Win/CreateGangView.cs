﻿using System;
using System.Windows.Forms;
using QWars.Dummy.Presenters;
using QWars.Presentation;

namespace QWars.Win
{
    public partial class CreateGangView : Form, ICreateGangView
    {
        private ICreateGangPresenter presenter;

        public CreateGangView()
        {
            InitializeComponent();
            presenter = new CreateGangPresenter(this);
        }

        private void CreateGangView_Load(object sender, EventArgs e)
        {
            presenter.Initialize();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            presenter.CreateGang();
            new BossView {PlayerId = PlayerId}.Show();
            Close();
        }

        public object PlayerId { get; set;}

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