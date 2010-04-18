using System;
using System.Windows.Forms;
using QWars.NHibernate.Presenters;
using QWars.Presentation;

namespace QWars.Win
{
    public partial class LogonView : Form
    {
        private readonly ILogonPresenter presenter;

        public LogonView()
        {
            InitializeComponent();
            presenter = new NHLogonPresenter();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var player = presenter.LoginWithPlayerName(txtPlayerName.Text);
            new PlayerView {Player = player}.Show();
        }
    }
}