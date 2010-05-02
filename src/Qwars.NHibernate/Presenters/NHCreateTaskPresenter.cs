using QWars.NHibernate.Entities;
using QWars.Presentation;

namespace QWars.NHibernate.Presenters
{
    public class NHCreateTaskPresenter : NHPresenter, ICreateTaskPresenter
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
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var task = new Task(view.Description, view.Difficulty, view.Reward, view.XP);
                session.Save(task);

                transaction.Commit();
            }
        }
    }
}