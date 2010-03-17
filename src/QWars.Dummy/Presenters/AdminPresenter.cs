using System;
using System.Collections.Generic;
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
            view.Data = new List<Player>
                            {
                                new Player(1, "Dolly"),
                                new Player(2, "Annie")
                            };
        }

        public void ShowRichestPlayers()
        {
            view.Title = "Richest Players";
            view.Data = new List<Player>
                            {
                                new Player(3, "Bill Gates"),
                                new Player(4, "Danny Gladines")
                            };
        }

        public void ShowBiggestGang()
        {
            view.Title = "Biggest Gang";
            view.Data = new List<Gang>
                            {
                                new Gang("QFrame"),
                                new Gang("4C Technologies")
                            };
        }
    }
}