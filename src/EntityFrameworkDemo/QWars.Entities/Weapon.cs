using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace QWars.Entities
{
    public abstract class Weapon : INotifyPropertyChanged
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

        private double _xpBonus;
        public virtual double XpBonus
        {
            get { return _xpBonus; }
            set
            {
                _xpBonus = value;
                PropertyChanged(this, new PropertyChangedEventArgs("XpBonus"));
            }
        }

        private int _price;
        public virtual int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Price"));
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

        public virtual int SellPrice
        {
            get { return Price * 6 / 10; }
        }
        #endregion

        #region Navigation Properties

        public virtual ObservableCollection<Player> OwnedBy
        {
            get
            {
                return _ownedBy;
            }
            set
            {
                if (!ReferenceEquals(_ownedBy, value))
                {
                    _ownedBy = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("OwnedBy"));
                }
            }
        }
        private ObservableCollection<Player> _ownedBy;

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged = delegate {};

        #endregion
    }
}
