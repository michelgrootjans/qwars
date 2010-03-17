using System;
using System.Collections.Generic;
using System.Linq;
using QWars.Dummy.Entities;
using QWars.Presentation;

namespace QWars.Dummy.Presenters
{
    public class JoinGangPresenter : IJoinGangPresenter
    {
        private readonly IJoinGangView view;
        private List<Gang> gangs;
        private Logger logger;

        public JoinGangPresenter(IJoinGangView view)
        {
            this.view = view;
            logger = new Logger(this);
        }

        public void Initialize()
        {
            gangs = new List<Gang>
                             {
                                 new Gang("The outlaws"),
                                 new Gang("The Flowerpot men")
                             };
            view.Gangs = gangs;
        }

        public void JoinGang()
        {
            logger.Log(string.Format("Player {0} joins '{1}'", view.Player, view.SelectedGang));
        }
    }
}