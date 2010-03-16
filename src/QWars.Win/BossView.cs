using System;
using System.Collections;
using System.Windows.Forms;
using QWars.Dummy.Presenters;
using QWars.Presentation;

namespace QWars.Win
{
    public partial class BossView : Form, IBossView
    {
        private readonly IBossPresenter presenter;

        public BossView()
        {
            InitializeComponent();
            presenter = new BossPresenter(this);
        }

        public string GangName
        {
            set { Text = value; }
        }

        public object PlayerId { get; set; }

        public int GangMoney
        {
            set { lblMoney.Text = string.Format("{0} $", value); }
        }

        public IEnumerable Members
        {
            set { gridMembers.DataSource = value; }
        }

        public int NumberOfMembers
        {
            set { lblNumberOfMembers.Text = string.Format("{0} members", value); }
        }

        public IEnumerable Tasks
        {
            set { gridTasks.DataSource = value; }
        }

        private void BossView_Load(object sender, EventArgs e)
        {
            presenter.Initialize();
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            new CreateTaskView {PlayerId = PlayerId}.Show();
        }

        private void btnCreateRandomTasks_Click(object sender, EventArgs e)
        {
            presenter.CreateRandomTasks();
        }

        private void btnIncreaseReward_Click(object sender, EventArgs e)
        {
            presenter.IncreaseRewardForAllTasks();
        }
    }
}