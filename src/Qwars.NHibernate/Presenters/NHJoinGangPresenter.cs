using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Presenters
{
    public class NHJoinGangPresenter : NHPresenter, IJoinGangPresenter
    {
        private readonly IJoinGangView view;

        public NHJoinGangPresenter(IJoinGangView joinGangView)
        {
            view = joinGangView;
        }

        public void Initialize()
        {
            using (var session = sessionFactory.OpenSession())
            {
                view.Gangs = session.CreateCriteria<IGang>().List<IGang>();
            }
        }

        public void JoinGang()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = GetPlayer(view.Player.Id, session);
                var gang = view.SelectedGang;

                player.Join(gang);

                transaction.Commit();
            }
        }
    }
}