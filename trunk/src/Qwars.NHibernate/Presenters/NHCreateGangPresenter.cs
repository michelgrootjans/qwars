using QWars.NHibernate.Entities;
using QWars.Presentation;
using QWars.Presentation.Entities;

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
            //Do nothing... nothing to do ;-)
        }

        public void CreateGang()
        {
            using (var transaction = session.BeginTransaction())
            {
                var boss = Get<IBoss>(view.Player.Id);
                boss.CreateGang(view.GangName, view.BossBenefit);
                transaction.Commit();
            }

        }
    }
}