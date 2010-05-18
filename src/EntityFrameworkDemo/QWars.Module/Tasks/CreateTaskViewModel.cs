using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Practices.Composite.Events;
using QWars.Entities;
using QWars.EntityFramework;
using QWars.Module.Common;
using QWars.Module.Common.Events;

namespace QWars.Module.Tasks
{
    class CreateTaskViewModel : INotifyPropertyChanged, ICloseableViewModel
    {
        #region Members
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string _description;
        private int _difficulty;
        private int _reward;
        private int _xp;
        #endregion

        #region Properties
        public IEventAggregator EventAggregator { get; private set; }
        public EventHandler RequestClose { get; set; }
        public QWarsContext Context { get; private set; }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Description"));
            }
        }
        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Difficulty"));
            }
        }
        public int Reward
        {
            get { return _reward; }
            set
            {
                _reward = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Reward"));
            }
        }
        public int XP
        {
            get { return _xp; }
            set
            {
                _xp = value;
                PropertyChanged(this, new PropertyChangedEventArgs("XP"));
            }
        }

        public RelayCommand<object> CancelCommand { get; private set; }
        public RelayCommand<object> CreateTaskCommand { get; private set; }
        #endregion

        #region Constructors
        public CreateTaskViewModel(IEventAggregator eventAggregator)
        {
            Context = new QWarsContext();

            #region Prism
            EventAggregator = eventAggregator;

            CancelCommand = new RelayCommand<object>(OnCancel);
            CreateTaskCommand = new RelayCommand<object>(OnCreateTask, OnCanCreateTask);
            #endregion
        }
        #endregion

        #region Commands
        private void OnCancel(object param)
        {
            CloseWindow();
        }
        private void OnCreateTask(object param)
        {
            var task = CreateTask();

            EventAggregator.GetEvent<CreateTaskEvent>().Publish(task);
            CloseWindow();
        }
        private bool OnCanCreateTask(object param)
        {
            return !string.IsNullOrWhiteSpace(Description)
                   && Difficulty > 0 && Difficulty < 100
                   && Reward > 0
                   && XP > 0;
        }
        #endregion

        #region Methods
        private Task CreateTask()
        {
            return new Task { Description = this.Description, Difficulty = this.Difficulty, Reward = this.Reward, XP = this.XP };
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
