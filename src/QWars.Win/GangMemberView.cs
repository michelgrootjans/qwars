using System;
using System.Collections;
using System.Windows.Forms;
using QWars.Dummy.Presenters;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.Win
{
    public partial class GangMemberView : Form, IGangMemberView
    {
        private readonly IGangMemberPresenter presenter;

        public GangMemberView()
        {
            InitializeComponent();
            presenter = new GangMemberPresenter(this);
        }

        public PlayerInfo PlayerId { get; set; }

        public ITask SelectedTask
        {
            get
            {
                if (gridTasks.SelectedRows.Count == 0) return null;

                return gridTasks.SelectedRows[0].DataBoundItem as ITask;
            }
        }

        public IEnumerable Tasks
        {
            set { gridTasks.DataSource = value; }
        }

        private void GangMemberView_Load(object sender, EventArgs e)
        {
            presenter.Initialize();
        }

        private void btnExecuteTask_Click(object sender, EventArgs e)
        {
            presenter.ExecuteTask();
        }
    }
}