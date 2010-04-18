using System;
using QWars.Presentation;

namespace QWars.NHibernate.Presenters
{
    public class NHAdminPresenter : IAdministratorPresenter
    {
        private readonly IAdministratorView view;

        public NHAdminPresenter(IAdministratorView view)
        {
            this.view = view;
        }

        public void ShowTopPlayers()
        {
            throw new NotImplementedException();
        }

        public void ShowRichestPlayers()
        {
            throw new NotImplementedException();
        }

        public void ShowBiggestGang()
        {
            throw new NotImplementedException();
        }
    }
}