using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Microsoft.Practices.Composite.Events;
using QWars.Entities;
using QWars.EntityFramework;
using QWars.Module.Common;
using System;
using QWars.Module.Common.Events;

namespace QWars.Module.Gangs
{
    class JoinGangViewModel : INotifyPropertyChanged, ICloseableViewModel
    {
        #region Members
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private ObservableCollection<Gang> _gangs;
        private Gang _selectedGang;
        #endregion

        #region Properties
        public IEventAggregator EventAggregator { get; private set; }
        public EventHandler RequestClose { get; set; }
        public QWarsContext Context { get; private set; }
        public ObservableCollection<Gang> Gangs
        {
            get
            {
                return _gangs;
            }
            set
            {
                _gangs = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Gangs"));
            }
        }
        public Gang SelectedGang
        {
            get { return _selectedGang; }
            set
            {
                _selectedGang = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedGang"));
            }
        }
        public RelayCommand<object> CancelCommand { get; private set; }
        public RelayCommand<object> JoinGangCommand { get; private set; }
        #endregion

        #region Constructors
        public JoinGangViewModel(IEventAggregator eventAggregator)
        {
            Context = new QWarsContext();

            #region Prism
            EventAggregator = eventAggregator;

            CancelCommand = new RelayCommand<object>(OnCancel);
            JoinGangCommand = new RelayCommand<object>(OnJoinGang);
            #endregion

            LoadData();
        }
        #endregion

        #region Commands
        private void OnCancel(object param)
        {
            CloseWindow();
        }
        private void OnJoinGang(object param)
        {
            if (SelectedGang == null) return;

            EventAggregator.GetEvent<GangJoinedEvent>().Publish(new GangInfo(SelectedGang.Id, SelectedGang.Name));

            CloseWindow();
        }
        #endregion

        #region Methods
        private void LoadData()
        {
            Gangs = new ObservableCollection<Gang>(Context.Gangs.ToList());
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
