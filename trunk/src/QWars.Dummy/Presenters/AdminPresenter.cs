using System.Linq;
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
            view.Data = InMemoryRepository.GetAllPlayers()
                .OrderByDescending(p => p.XP).ToList();
        }

        public void ShowRichestPlayers()
        {
            view.Title = "Richest Players";
            view.Data = InMemoryRepository.GetAllPlayers()
                .OrderByDescending(p => p.Money).ToList();
        }

        public void ShowBiggestGang()
        {
            view.Title = "Biggest Gang";
            view.Data = InMemoryRepository.GetAllGangs().ToList();
        }
    }
}