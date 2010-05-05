using QWars.Presentation;
using QWars.Presentation.Entities;

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
            //Do nothing...nothing to do ;-)
        }

        public void CreateTask()
        {
            using (var transaction = session.BeginTransaction())
            {
                var boss = Get<IBoss>(view.Player.Id);
                boss.CreateTask(view.Description, view.Difficulty, view.Reward, view.XP);
                transaction.Commit();
            }
        }
    }
}