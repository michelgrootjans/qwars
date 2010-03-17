using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QWars.Dummy.Presenters;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.Win
{
    public partial class BossView : Form, IBossView
    {
        private readonly IBossPresenter presenter;
        public IPlayerInfo Player { get; set; }

        public BossView()
        {
            InitializeComponent();
            presenter = new BossPresenter(this);
        }

        private void BossView_Load(object sender, EventArgs e)
        {
            presenter.Initialize();
        }

        public string GangName
        {
            set { Text = value; }
        }

        public int GangMoney
        {
            set { lblMoney.Text = string.Format("{0} $", value); }
        }

        public IEnumerable<IPlayer> Members
        {
            set { gridMembers.DataSource = value; }
        }

        public int NumberOfMembers
        {
            set { lblNumberOfMembers.Text = string.Format("{0} members", value); }
        }

        public IEnumerable<ITask> Tasks
        {
            set { gridTasks.DataSource = value; }
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            new CreateTaskView {Player = Player}.Show();
        }

        private void btnCreateRandomTasks_Click(object sender, EventArgs e)
        {
            presenter.CreateRandomTasks();
            //BUG: grid doesn't refresh
        }

        private void btnIncreaseReward_Click(object sender, EventArgs e)
        {
            presenter.IncreaseRewardForAllTasks();
        }
    }
}