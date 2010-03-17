using System;
using System.Windows.Forms;
using QWars.Dummy.Presenters;
using QWars.Presentation;

namespace QWars.Win
{
    public partial class LogonView : Form
    {
        private readonly ILogonPresenter presenter;

        public LogonView()
        {
            InitializeComponent();
            presenter = new LogonPresenter();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var playerId = presenter.LoginWithPlayerName(txtPlayerName.Text);
            new PlayerView{PlayerId = playerId}.Show();
        }
    }
}