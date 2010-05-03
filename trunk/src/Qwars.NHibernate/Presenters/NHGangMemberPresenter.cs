using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Presenters
{
    public class NHGangMemberPresenter : NHPresenter, IGangMemberPresenter
    {
        private readonly IGangMemberView view;

        public NHGangMemberPresenter(IGangMemberView view)
        {
            this.view = view;
        }

        public void Initialize()
        {
            using (var session = sessionFactory.OpenSession())
            {
                var boss = Get<IBoss>(view.Player.Id, session);
                view.Tasks = boss.GetGangTasks();
            }
        }

        public void ExecuteTask()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = Get<IPlayer>(view.Player.Id, session);
                player.Execute(view.SelectedTask);
                transaction.Commit();
            }
        }
    }
}