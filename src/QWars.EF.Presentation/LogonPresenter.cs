using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QWars.Presentation;

namespace QWars.EF.Presentation
{
    public class LogonPresenter : PresenterBase, ILogonPresenter
    {
        #region ILogonPresenter Members

        public QWars.Presentation.Entities.PlayerInfo LoginWithPlayerName(string playerName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
