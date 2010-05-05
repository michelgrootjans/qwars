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
            using (var transaction = session.BeginTransaction())
            {
                view.Gangs = session.CreateCriteria<IGang>()
                    .List<IGang>();
                transaction.Commit();
            }
        }

        public void JoinGang()
        {
            using (var transaction = session.BeginTransaction())
            {
                var player = Get<IPlayer>(view.Player.Id);
                var gang = view.SelectedGang;
                session.SaveOrUpdate(gang);
                player.Join(gang);
                transaction.Commit();
            }
        }
    }
}