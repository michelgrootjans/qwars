using QWars.Presentation;

namespace QWars.NHibernate.Presenters
{
    public class NHCreateTaskPresenter : ICreateTaskPresenter
    {
        private readonly ICreateTaskView view;

        public NHCreateTaskPresenter(ICreateTaskView view)
        {
            this.view = view;
        }

        public void Initialize()
        {
        }

        public void CreateTask()
        {
        }
    }
}