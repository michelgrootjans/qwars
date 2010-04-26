using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QWars.Presentation.Entities;

namespace QWars.EF.Entities
{
    public partial class Weapon : IWeapon
    {
        public virtual int Id
        {
            get;
            set;
        }

        public virtual double XpBonus
        {
            get;
            protected set;
        }

        public virtual int Price
        {
            get;
            protected set;
        }

        public virtual string Name
        {
            get { return "Weapon"; }
        }

        public virtual int SellPrice
        {
            get { return Price * 6 / 10; }
        }
    }
}
