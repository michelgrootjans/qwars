using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QWars.EF.Entities
{
    public partial class Knife : Weapon
    {
        public override string Name
        {
            get
            {
                return "Knife";
            }
        }
    }
}
