using System.Collections.Generic;
using System.Linq;
using QWars.Dummy.Entities;
using QWars.Presentation;

namespace QWars.Dummy.Presenters
{
    public class AdminPresenter : IAdministratorPresenter
    {
        private readonly IAdministratorView view;

        public AdminPresenter(IAdministratorView view)
        {
            this.view = view;
        }

        public void ShowTopPlayers()
        {
            view.Title = "Top Players";
            view.Data = Repository.GetAllPlayers().OrderBy(p => p.XP);
        }

        public void ShowRichestPlayers()
        {
            view.Title = "Richest Players";
            view.Data = Repository.GetAllPlayers().OrderBy(p => p.Money);
        }

        public void ShowBiggestGang()
        {
            view.Title = "Biggest Gang";
            view.Data = Repository.GetAllGangs();
        }
    }
}