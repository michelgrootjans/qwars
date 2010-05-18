using System;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using QWars.Entities;
using QWars.EntityFramework;
using QWars.Module.Common;

namespace QWars.Module.Logon
{
    class LogonViewModel : INotifyPropertyChanged, IViewModel
    {
        #region Members
        public event PropertyChangedEventHandler PropertyChanged = delegate {};
        private readonly IEventAggregator eventAggregator;
        private string _playerName;
        #endregion

        #region Properties
        public DelegateCommand<object> LogonCommand { get; private set; }
        public string PlayerName
        {
            get 
            { 
                return _playerName; 
            }
            set 
            { 
                _playerName = value; 
                PropertyChanged(this, new PropertyChangedEventArgs("PlayerName")); 
            }
        }
        #endregion

        #region Constructors
        public LogonViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            LogonCommand = new DelegateCommand<object>(OnLogon);
        }
        #endregion

        #region Commands
        private void OnLogon(object param)
        {
            var playerInfo = LoginWithPlayerName(PlayerName);
            eventAggregator.GetEvent<PlayerChangedEvent>().Publish(playerInfo);
        }
        #endregion

        #region Methods
        private PlayerInfo LoginWithPlayerName(string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName)) return null;

            using( var context = new QWarsContext())
            {
                context.Players.MergeOption = MergeOption.OverwriteChanges;

                //Entity SQL
                //var eSQLQuery = "select VALUE p.Id from Players as p where p.Name == @playerName";
                //var query = context.CreateQuery<int>(eSQLQuery, new ObjectParameter[] { new ObjectParameter("playerName", playerName) });
                

                //Linq 2 Entities
                var query = from player in context.Players
                            where player.Name == playerName
                            select player.Id;

                var playerId = query.SingleOrDefault();
                
                if (playerId == 0)
                {
                    var newPlayer = new Player { Name = playerName, XP = 5, Money = 5 };
                    context.Players.AddObject(newPlayer);
                    context.SaveChanges();
                    playerId = newPlayer.Id;
                }


                return new PlayerInfo(playerId, playerName);
            }
        }
        #endregion
    }
}
