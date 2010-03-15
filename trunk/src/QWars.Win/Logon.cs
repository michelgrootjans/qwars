using System;
using System.Windows.Forms;
using QWars.Dummy;
using QWars.Presentation;

namespace QWars.Win
{
    public partial class Logon : Form
    {
        private readonly ILogonPresenter presenter;

        public Logon()
        {
            InitializeComponent();
            presenter = new LogonPresenter();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PlayerId = presenter.LoginWithPlayerName(txtPlayerName.Text);
            Close();
        }

        public object PlayerId { get; private set; }
    }
}