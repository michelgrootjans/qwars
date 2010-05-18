using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using QWars.Entities;
using QWars.EntityFramework;
using QWars.Module.Common;
using QWars.Module.Common.Events;

namespace QWars.Module.Gangs
{
    class CreateGangViewModel: INotifyPropertyChanged, ICloseableViewModel
    {
        #region Members
        private string _gangName;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion

        #region Properties
        public string GangName
        {
            get
            {
                return _gangName;
            }
            set
            {
                _gangName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GangName"));
            }
        }

        public IEventAggregator EventAggregator { get; private set; }
        public EventHandler RequestClose { get; set; }
        public QWarsContext Context { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }
        public RelayCommand<object> CreateGangCommand { get; private set; }
        #endregion

        #region Constructors
        public CreateGangViewModel(IEventAggregator eventAggregator)
        {
            Context = new QWarsContext();

            #region Prims
            EventAggregator = eventAggregator;

            CancelCommand = new RelayCommand<object>(OnCancel);
            CreateGangCommand = new RelayCommand<object>(OnCreateGang, OnCanCreateGang);
            #endregion
        }
        #endregion

        #region Commands
        private void OnCancel(object param)
        {
            CloseWindow();
        }
        private void OnCreateGang(object param)
        {
            var gang = CreateGang();

            EventAggregator.GetEvent<GangCreatedEvent>().Publish(gang);

            CloseWindow();
        }
        private bool OnCanCreateGang(object param)
        {
            return !string.IsNullOrWhiteSpace(GangName);
        }
        #endregion

        #region Methods
        private Gang CreateGang()
        {
            Gang gang = null;

            if (!string.IsNullOrWhiteSpace(GangName)
                && Context.Gangs.FirstOrDefault(g => g.Name == GangName) == null)
            {
                gang = new Gang {Name = GangName};
            }

            return gang;
        }
        private void CloseWindow()
        {
            var handler = RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion

    }
}
