using System;
using QWars.Presentation;

namespace QWars.Dummy.Presenters
{
    public class CreateTaskPresenter : ICreateTaskPresenter
    {
        private readonly ICreateTaskView view;
        private Logger logger;

        public CreateTaskPresenter(ICreateTaskView view)
        {
            this.view = view;
            logger = new Logger(this);
        }

        public void Initialize()
        {
            //Do nothing...nothing to do ;-)
        }

        public void CreateTask()
        {
            logger.Log(string.Format("Player {0} creates a new task: Diff {1} - Reward {2} - XP {3}", 
                view.PlayerId, view.Difficulty, view.Reward, view.XP));
        }
    }
}