using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QWars.EF.Entities
{
    public partial class Taser : Weapon
    {
        public override string Name
        {
            get
            {
                return "Taser";
            }
        }
    }
}
