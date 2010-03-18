using System;
using System.Collections;
using System.Windows.Forms;
using QWars.Dummy.Presenters;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.Win
{
    public partial class JoinGangView : Form, IJoinGangView
    {
        private readonly IJoinGangPresenter presenter;
        public PlayerInfo Player { get; set; }

        public JoinGangView()
        {
            InitializeComponent();
            presenter = new JoinGangPresenter(this);
        }


        private void JoinGangView_Load(object sender, EventArgs e)
        {
            presenter.Initialize();
        }

        private void btnJoinGang_Click(object sender, EventArgs e)
        {
            presenter.JoinGang();
            new GangMemberView {Player = Player}.Show();
            Close();
        }

        public IEnumerable Gangs
        {
            set { gridGangs.DataSource = value; }
        }

        public IGang SelectedGang
        {
            get
            {
                if (gridGangs.SelectedRows.Count == 0) return null;
                
                return gridGangs.SelectedRows[0].DataBoundItem as IGang;
            }
        }
    }
}