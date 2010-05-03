using QWars.Presentation;
using QWars.Presentation.Entities;

namespace QWars.NHibernate.Presenters
{
    public class NHAdminPresenter : NHPresenter, IAdministratorPresenter
    {
        private readonly IAdministratorView view;

        public NHAdminPresenter(IAdministratorView view)
        {
            this.view = view;
        }

        public void ShowTopPlayers()
        {
            view.Title = "Top Players according to NHibernate";

            using (var session = sessionFactory.OpenSession())
            {
                view.Data = session.CreateCriteria<IPlayer>().List();
            }
        }

        public void ShowRichestPlayers()
        {
            view.Title = "Richest Players according to NHibernate";
            using (var session = sessionFactory.OpenSession())
            {
                view.Data = session.CreateCriteria<IPlayer>().List();
            }
        }

        public void ShowBiggestGang()
        {
            view.Title = "Biggest Gang according to NHibernate";
            using (var session = sessionFactory.OpenSession())
            {
                view.Data = session.CreateCriteria<IGang>().List();
            }
        }
    }
}