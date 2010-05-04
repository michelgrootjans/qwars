using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Presenters
{
    public class NHJoinGangPresenter : NHPresenter, IJoinGangPresenter
    {
        private readonly IJoinGangView view;

        public NHJoinGangPresenter(IJoinGangView view)
        {
            this.view = view;
        }

        public void Initialize()
        {
            using (var session = sessionFactory.OpenSession())
            {
                view.Gangs = session.CreateCriteria<IGang>()
                    .List<IGang>();
            }
        }

        public void JoinGang()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = Get<IPlayer>(view.Player.Id, session);
                var gang = view.SelectedGang;
                session.Update(gang);
                player.Join(gang);
                transaction.Commit();
            }
        }
    }
}