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
                                new Player("Dolly"),
                                new Player("Annie")
                            };
        }

        public void ShowRichestPlayers()
        {
            view.Title = "Richest Players";
            view.Data = new List<Player>
                            {
                                new Player("Bill Gates"),
                                new Player("Danny Gladines")
                            };
        }

        public void ShowBiggestGang()
        {
            view.Title = "Biggest Gang";
            view.Data = new List<Player>
                            {
                                new Player("QFrame"),
                                new Player("4C Technologies")
                            };
        }
    }
}