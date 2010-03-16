using System;
using System.Windows.Forms;
using QWars.Dummy.Presenters;
using QWars.Presentation;

namespace QWars.Win
{
    public partial class CreateTaskView : Form, ICreateTaskView
    {
        private readonly ICreateTaskPresenter presenter;
        public object PlayerId { get; set; }

        public CreateTaskView()
        {
            InitializeComponent();
            presenter = new CreateTaskPresenter(this);
        }

        public string Difficulty
        {
            get { return txtDifficulty.Text; }
        }

        public string Reward
        {
            get { return txtReward.Text; }
        }

        public string XP
        {
            get { return txtXP.Text; }
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
