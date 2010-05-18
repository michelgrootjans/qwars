using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Linq;
using Microsoft.Practices.Composite.Events;
using QWars.Entities;
using QWars.EntityFramework;
using QWars.Module.Common;
using QWars.Module.Common.Events;
using QWars.Module.Tasks;

namespace QWars.Module.Gangs
{
    class GangViewModel : INotifyPropertyChanged, IViewModel
    {
        #region Members
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private Gang _gang;
        private Task _selectedTask;
        #endregion

        #region Properties
        public IEventAggregator EventAggregator { get; private set; }
        public IDialogService DialogService { get; private set; }

        public QWarsContext Context { get; private set; }

        public Gang Gang
        {
            get
            {
                return _gang;
            }
            set
            {
                _gang = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Gang"));
            }
        }
        public Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedTask"));
            }
        }
        public PlayerInfo PlayerInfo { get; private set; }

        public RelayCommand<object> GangStatisticsCommand { get; private set; }
        public RelayCommand<object> DisbandGangCommand { get; private set; }
        public RelayCommand<object> CreateTaskCommand { get; private set; }
        public RelayCommand<object> ExecuteTaskCommand { get; private set; }

        #endregion

        #region Constructors
        public GangViewModel(IEventAggregator eventAggregator, IDialogService dialogService)
        {
            Context = new QWarsContext();
            Context.Gangs.MergeOption = MergeOption.OverwriteChanges;

            #region Prism 
            EventAggregator = eventAggregator;
            DialogService = dialogService;

            eventAggregator.GetEvent<PlayerChangedEvent>().Subscribe(OnPlayerChanged);
            eventAggregator.GetEvent<CreateTaskEvent>().Subscribe(OnTaskCreated);

            GangStatisticsCommand = new RelayCommand<object>(OnShowGangStatistics, OnCanShowGangStatistics);
            DisbandGangCommand = new RelayCommand<object>(OnDisbandGang, OnCanDisbandGang);

            CreateTaskCommand = new RelayCommand<object>(OnCreateTask, OnCanCreateTask);
            ExecuteTaskCommand = new RelayCommand<object>(OnExecuteTask, OnCanExecuteTask);
            #endregion
        }
        #endregion

        #region Events
        private void OnPlayerChanged(PlayerInfo playerInfo)
        {
            PlayerChanged(playerInfo);
        }
        private void OnTaskCreated(Task task)
        {
            CreateTask(task);
        }
        #endregion

        #region Commands
        #region Gang Statistics
        public void OnShowGangStatistics(object param)
        {
            
        }
        public bool OnCanShowGangStatistics(object param)
        {
            return false;
        }
        #endregion

        #region DisbandGang
        public void OnDisbandGang(object param)
        {
            DisbandGang();
        }
        public bool OnCanDisbandGang(object param)
        {
            return PlayerInfo != null && Gang != null && Gang.Boss != null && PlayerInfo.Id == Gang.Boss.Id;
        }
        #endregion

        #region CreateTask
        public void OnCreateTask(object param)
        {
            DialogService.ShowViewModelInDialog<CreateTaskView, CreateTaskViewModel>();
        }
        public bool OnCanCreateTask(object param)
        {
            return PlayerInfo != null && Gang != null && Gang.Boss != null && PlayerInfo.Id == Gang.Boss.Id;
        }
        #endregion

        #region ExecuteTask
        public void OnExecuteTask(object param)
        {
            ExecuteTask();
            EventAggregator.GetEvent<PlayerChangedEvent>().Publish(PlayerInfo);
        }
        public bool OnCanExecuteTask(object param)
        {
            return PlayerInfo != null && Gang != null && SelectedTask != null && PlayerInfo.Id != Gang.Boss.Id && SelectedTask.ExecutedBy == null;
        }
        #endregion
        #endregion

        #region Methods
        private void PlayerChanged(PlayerInfo playerInfo)
        {
            PlayerInfo = playerInfo;

            var query = from player in Context.Players.Include("Tasks")
                        where player.Id == playerInfo.Id
                        select player.MemberOf;
            Gang = query.SingleOrDefault();
        }
        private void CreateTask(Task task)
        {
            Gang.Tasks.Add(task);
            Context.SaveChanges();
        }
        private void DisbandGang()
        {
            Context.ExecuteFunction("DeleteGang", new ObjectParameter("gangId", Gang.Id));
            Context.Refresh(RefreshMode.StoreWins, Gang);
            EventAggregator.GetEvent<PlayerChangedEvent>().Publish(PlayerInfo);
        }
        private void ExecuteTask()
        {
            var player = Gang.Members.SingleOrDefault(p => p.Id == PlayerInfo.Id);

            if (player == null) return;

            player.ExecuteTask(SelectedTask);

            if (SelectedTask.Outcome.Value)
                Gang.Money += SelectedTask.Reward * 10;

            Context.SaveChanges();
        }
        #endregion
    }
}
