using QWars.NHibernate.Entities;
using QWars.Presentation;

namespace QWars.NHibernate.Presenters
{
    public class NHCreateGangPresenter : NHPresenter, ICreateGangPresenter
    {
        private readonly ICreateGangView view;

        public NHCreateGangPresenter(ICreateGangView view)
        {
            this.view = view;
        }

        public void Initialize()
        {
        }

        public void CreateGang()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = session.Get<Player>(view.Player.Id);
                var gang = new Gang(player, view.GangName);
                session.Save(gang);
                transaction.Commit();
            }

        }
    }
}