using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using QWars.Entities;
using QWars.EntityFramework;
using QWars.Module.Common;
using QWars.Module.Common.Events;

namespace QWars.Module.Weapons
{
    class BuyWeaponViewModel : INotifyPropertyChanged, ICloseableViewModel
    {
        #region Members
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private ObservableCollection<Weapon> _weapons;
        private Weapon _selectedWeapon;
        #endregion

        #region Properties
        public IEventAggregator EventAggregator { get; private set; }
        public EventHandler RequestClose { get; set; }
        public QWarsContext Context { get; private set; }
        public ObservableCollection<Weapon> Weapons
        {
            get
            {
                return _weapons;
            }
            set
            {
                _weapons = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Weapons"));
            }
        }
        public Weapon SelectedWeapon
        {
            get { return _selectedWeapon; }
            set
            {
                _selectedWeapon = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedWeapon"));
            }
        }
        public RelayCommand<object> CancelCommand { get; private set; }
        public RelayCommand<object> BuyWeaponCommand { get; private set; }
        #endregion

        #region Constructors
        public BuyWeaponViewModel(IEventAggregator eventAggregator)
        {
            Context = new QWarsContext();

            #region Prism
            EventAggregator = eventAggregator;

            CancelCommand = new RelayCommand<object>(OnCancel);
            BuyWeaponCommand = new RelayCommand<object>(OnBuyWeapon);
            #endregion

            LoadData();
        }
        #endregion
        
        #region Commands
        private void OnCancel(object param)
        {
            CloseWindow();
        }
        private void OnBuyWeapon(object param)
        {
            if (SelectedWeapon == null) return;
            
            EventAggregator.GetEvent<BuyWeaponEvent>().Publish(new WeaponInfo(SelectedWeapon.Id, SelectedWeapon.Name));

            CloseWindow();
        }
        #endregion

        #region Methods
        private void LoadData()
        {
            Weapons = new ObservableCollection<Weapon>(Context.Weapons.ToList());
        }
        private void CloseWindow()
        {
            EventHandler handler = RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion

    }
}
