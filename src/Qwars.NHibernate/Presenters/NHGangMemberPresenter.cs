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
            using (var transaction = session.BeginTransaction())
            {
                var boss = Get<IPlayer>(view.Player.Id);
                UpdateView(boss);
                transaction.Commit();
            }
        }

        public void ExecuteTask()
        {
            using (var transaction = session.BeginTransaction())
            {
                var player = Get<IPlayer>(view.Player.Id);
                player.Execute(view.SelectedTask);
                transaction.Commit();
            }
        }

        private void UpdateView(IPlayer boss)
        {
            view.Tasks = boss.GetGangTasks();
        }
    }
}