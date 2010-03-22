using System;
using System.Windows.Forms;
using QWars.Dummy.Presenters;
using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.Win
{
    public partial class CreateTaskView : Form, ICreateTaskView
    {
        private readonly ICreateTaskPresenter presenter;
        public PlayerInfo Player { get; set; }
        public CreateTaskView()
        {
            InitializeComponent();
            presenter = new CreateTaskPresenter(this);
        }

        public string Description
        {
            get { return txtDescription.Text; }
        }

        public int Difficulty
        {
            get { return Convert.ToInt32(txtDifficulty.Text); }
        }

        public int Reward
        {
            get { return Convert.ToInt32(txtReward.Text); }
        }

        public int XP
        {
            get { return Convert.ToInt32(txtXP.Text); }
        }


        private void CreateTaskView_Load(object sender, EventArgs e)
        {
            presenter.Initialize();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            presenter.CreateTask();
            Close();
        }
    }
}
