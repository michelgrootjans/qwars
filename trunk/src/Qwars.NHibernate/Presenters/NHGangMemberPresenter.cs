using NHibernate.Criterion;
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
                var player = GetPlayer(view.Player.Id, session);
                var gang = session.CreateCriteria<IGang>()
                    .Add(Restrictions.In("Members", new[] {player}))
                    .UniqueResult<IGang>();

                view.Tasks = gang.Tasks;
            }
        }

        public void ExecuteTask()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = GetPlayer(view.Player.Id, session);
                player.Execute(view.SelectedTask);

                transaction.Commit();
            }
        }
    }
}