using System;
using QWars.Presentation;

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
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {

                transaction.Commit();
            }
        }

        public void ShowRichestPlayers()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {

                transaction.Commit();
            }
        }

        public void ShowBiggestGang()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {

                transaction.Commit();
            }
        }
    }
}