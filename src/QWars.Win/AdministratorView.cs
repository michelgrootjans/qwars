using System;
using System.Collections;
using System.Windows.Forms;
using QWars.NHibernate.Presenters;
using QWars.Presentation;

namespace QWars.Win
{
    public partial class AdministratorView : Form, IAdministratorView
    {
        private readonly IAdministratorPresenter presenter;

        public AdministratorView()
        {
            InitializeComponent();
            presenter = new NHAdminPresenter(this);
        }

        private void AdministratorView_Load(object sender, EventArgs e)
        {
            new LogonView().Show();
        }

        private void btnTopPlayers_Click(object sender, EventArgs e)
        {
            presenter.ShowTopPlayers();
        }

        private void btnRichestPlayer_Click(object sender, EventArgs e)
        {
            presenter.ShowRichestPlayers();
        }

        private void btnBiggestGangs_Click(object sender, EventArgs e)
        {
            presenter.ShowBiggestGang();
        }

        public IEnumerable Data
        {
            set { gridReport.DataSource = value; }
        }

        public string Title
        {
            set { Text = value; }
        }
    }
}