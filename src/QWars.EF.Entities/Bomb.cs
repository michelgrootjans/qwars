using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QWars.EF.Entities
{
    public partial class Bomb : Weapon
    {
        public override string Name
        {
            get
            {
                return "Bomb";
            }
        }
    }
}
