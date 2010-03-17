using System;
using System.Collections;
using System.Windows.Forms;
using QWars.Dummy.Presenters;
using QWars.Presentation;

namespace QWars.Win
{
    public partial class GangMemberView : Form, IGangMemberView
    {
        private IGangMemberPresenter presenter;

        public GangMemberView()
        {
            InitializeComponent();
            presenter = new GangMemberPresenter(this);
        }

        public object PlayerId { get; set; }
        public object SelectedTask
        {
            get
            {
                if (gridTasks.SelectedRows.Count == 0) return null;

                return gridTasks.SelectedRows[0].DataBoundItem;
            }
        }

        public IEnumerable Tasks
        {
            set { gridTasks.DataSource = value; }
        }

        private void GangMemberView_Load(object sender, System.EventArgs e)
        {
            presenter.Initialize();
        }

        private void btnExecuteTask_Click(object sender, System.EventArgs e)
        {
            presenter.ExecuteTask();
        }
    }
}