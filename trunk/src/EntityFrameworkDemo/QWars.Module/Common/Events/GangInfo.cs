using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QWars.Module.Common.Events
{
    public class GangInfo
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public GangInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("GangInfo({0} - {1})", Id, Name);
        }
    }
}
