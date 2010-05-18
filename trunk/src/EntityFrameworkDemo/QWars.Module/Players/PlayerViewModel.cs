using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Linq;
using Microsoft.Practices.Composite.Events;
using QWars.Entities;
using QWars.EntityFramework;
using QWars.Module.Common;
using QWars.Module.Common.Events;
using QWars.Module.Gangs;
using QWars.Module.Weapons;

namespace QWars.Module.Players
{
    class PlayerViewModel : INotifyPropertyChanged, IViewModel
    {
        #region Members
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private Player _player;
        #endregion

        #region Properties
        public IEventAggregator EventAggregator { get; private set; }
        public IDialogService DialogService  { get; private set; }

        public QWarsContext Context { get; private set; }

        public Player Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Player"));
            }
        }
        public PlayerInfo PlayerInfo { get; private set; }

        public RelayCommand<object> SellWeaponsCommand { get; private set; }
        public RelayCommand<object> BuyWeaponCommand { get; private set; }
        public RelayCommand<object> JoinGangCommand { get; private set; }
        public RelayCommand<object> CreateGangCommand { get; private set; }
        public RelayCommand<object> MugPedestrianCommand { get; private set; }
        
        #endregion

        #region Constructors
        public PlayerViewModel(IEventAggregator eventAggregator, IDialogService dialogService)
        {
            Context = new QWarsContext();
            Context.Players.MergeOption = MergeOption.OverwriteChanges;

            #region Prism
            EventAggregator = eventAggregator;
            DialogService = dialogService;

            eventAggregator.GetEvent<PlayerChangedEvent>().Subscribe(OnPlayerChanged);
            eventAggregator.GetEvent<BuyWeaponEvent>().Subscribe(OnWeaponBought);
            eventAggregator.GetEvent<GangCreatedEvent>().Subscribe(OnGangCreated);
            eventAggregator.GetEvent<GangJoinedEvent>().Subscribe(OnGangJoined);

            SellWeaponsCommand = new RelayCommand<object>(OnSellWeapons, OnCanSellWeapons);
            BuyWeaponCommand = new RelayCommand<object>(OnBuyWeapon, OnCanBuyWeapon);

            JoinGangCommand = new RelayCommand<object>(OnJoinGang, OnCanJoinGang);
            CreateGangCommand = new RelayCommand<object>(OnCreateGang, OnCanCreateGang);
            MugPedestrianCommand = new RelayCommand<object>(OnMugPedestrian, OnCanMugPedestrian);
            #endregion
        }
        #endregion

        #region Commands
        #region SellWeapons
        private void OnSellWeapons(object param)
        {
            SellWeapons();
        }
        /// <summary>
        /// Weapons can only be sold when a player has more than 1 weapon
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private bool OnCanSellWeapons(object param)
        {
            return Player != null && Player.Weapons != null && Player.Weapons.Count > 1;
        }
        #endregion

        #region BuyWeapon
        private void OnBuyWeapon(object param)
        {
            DialogService.ShowViewModelInDialog<BuyWeaponView, BuyWeaponViewModel>();
        }

        /// <summary>
        /// A Weapon can only be bought when a player has money
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private bool OnCanBuyWeapon(object param)
        {
            return Player != null && Player.Money > 0;
        }
        #endregion

        #region JoinGang
        private void OnJoinGang(object param)
        {
            DialogService.ShowViewModelInDialog<JoinGangView, JoinGangViewModel>();
        }

        /// <summary>
        /// A Gang can only be joined when a player isn't member or owner of a gang and if he has more than 100 XP
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private bool OnCanJoinGang(object param)
        {
            return Player != null && Player.MemberOf == null && Player.OwnerOf == null && Player.XP > 100;
        }
        #endregion

        #region CreateGang
        private void OnCreateGang(object param)
        {
            DialogService.ShowViewModelInDialog<CreateGangView, CreateGangViewModel>();
        }
        
        /// <summary>
        /// A Gang can only be created when a player isn't member or owner of a gang and if he has more than 1000 XP
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private bool OnCanCreateGang(object param)
        {
            return Player != null && Player.OwnerOf == null && Player.MemberOf == null && Player.XP > 1000;
        }
        #endregion

        #region MugPedestrian
        private void OnMugPedestrian(object param)
        {
            MugPedestrian();
        }
        
        /// <summary>
        /// A Player can only mug a pedestrian when he has XP
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private bool OnCanMugPedestrian(object param)
        {
            return Player != null && Player.XP >= 0;
        }
        #endregion

        #endregion

        #region Events
        private void OnPlayerChanged(PlayerInfo playerInfo)
        {
            ChangePlayer(playerInfo);
        }
        private void OnWeaponBought(WeaponInfo weaponInfo)
        {
            BuyWeapon(weaponInfo);
        }
        private void OnGangJoined(GangInfo gangInfo)
        {
            JoinGang(gangInfo);

            EventAggregator.GetEvent<PlayerChangedEvent>().Publish(new PlayerInfo(Player.Id, Player.Name));
        }
        private void OnGangCreated(Gang gang)
        {
            CreateGang(gang);

            EventAggregator.GetEvent<PlayerChangedEvent>().Publish(new PlayerInfo(Player.Id, Player.Name));
        }
        #endregion

        #region Methods
        private void ChangePlayer(PlayerInfo playerInfo)
        {
            PlayerInfo = playerInfo;

            Player = Context.GetObjectByKey(new EntityKey("QWarsContext.Players", "Id", playerInfo.Id)) as Player;

            //Player = Context.Players
            //            .Include("Weapons")
            //            .SingleOrDefault(p => p.Id == playerInfo.Id);
        }
        private void BuyWeapon(WeaponInfo weaponInfo)
        {
            if (weaponInfo == null) return;
            var weapon = Context.Weapons.SingleOrDefault(w => w.Id == weaponInfo.Id);

            if (weapon == null || Player.Money < weapon.Price || Player.Weapons.Any(w => w.Id == weapon.Id)) return;

            Player.BuyWeapon(weapon);
            Context.SaveChanges();
        }
        private void JoinGang(GangInfo gangInfo)
        {
            var gang = Context.Gangs.SingleOrDefault(g => g.Id == gangInfo.Id);
            Player.MemberOf = gang;
            Context.SaveChanges();
        }
        private void CreateGang(Gang gang)
        {
            Player.OwnerOf = gang;
            Player.OwnerOf.Boss = Player;
            Player.MemberOf = gang;
            Context.SaveChanges();
        }

        private void SellWeapons()
        {
            if (Player == null || Player.Weapons == null || Player.Weapons.Count() == 0) return;

            Player.SellUselessWeapons();
            Context.SaveChanges();
        }
        private void MugPedestrian()
        {
            Player.ExecuteTask(new Mugging());
            Context.SaveChanges();
        }
        #endregion
    }
}
