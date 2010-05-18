using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace QWars.Entities
{
    public partial class Gang : INotifyPropertyChanged
    {
        #region Primitive Properties

        private int _id;
        public virtual int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Id"));
            }
        }

        private string _name;
        public virtual string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        private int _money;
        public virtual int Money
        {
            get { return _money; }
            set
            {
                _money = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Money"));
            }
        }

        #endregion

        #region Navigation Properties

        public virtual ObservableCollection<Player> Members
        {
            get
            {
                return _members;
            }
            set
            {
                if (!ReferenceEquals(_members, value))
                {
                    _members = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Members"));
                }
            }
        }
        private ObservableCollection<Player> _members;

        public virtual ObservableCollection<Task> Tasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                if (!ReferenceEquals(_tasks, value))
                {
                    _tasks = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Tasks"));
                }
            }
        }
        private ObservableCollection<Task> _tasks;

        public virtual Player Boss
        {
            get { return _boss; }
            set
            {
                if (!ReferenceEquals(_boss, value))
                {
                    _boss = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Boss"));
                }
            }
        }
        private Player _boss;

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion
    }
}
