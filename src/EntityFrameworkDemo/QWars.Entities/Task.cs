using System.ComponentModel;

namespace QWars.Entities
{
    public partial class Task : INotifyPropertyChanged
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

        private string _description;
        public virtual string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Description"));
            }
        }

        private int _difficulty;
        public virtual int Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Difficulty"));
            }
        }

        private int _reward;
        public virtual int Reward
        {
            get { return _reward; }
            set
            {
                _reward = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Reward"));
            }
        }

        private int _xp;
        public virtual int XP
        {
            get { return _xp; }
            set
            {
                _xp = value;
                PropertyChanged(this, new PropertyChangedEventArgs("XP"));
            }
        }

        private bool? _outcome;
        public virtual bool? Outcome
        {
            get { return _outcome; }
            set
            {
                _outcome = value;
                PropertyChanged(this, new PropertyChangedEventArgs("OutCome"));
            }
        }

        #endregion

        #region Navigation Properties

        public virtual Gang Gang
        {
            get { return _gang; }
            set
            {
                if (!ReferenceEquals(_gang, value))
                {
                    _gang = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Gang"));
                }
            }
        }
        private Gang _gang;

        public virtual Player ExecutedBy
        {
            get { return _executedBy; }
            set
            {
                if (!ReferenceEquals(_executedBy, value))
                {
                    _executedBy = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ExecutedBy"));
                }
            }
        }
        private Player _executedBy;

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion
    }
}
