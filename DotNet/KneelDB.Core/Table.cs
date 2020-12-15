using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.Core
{
    public class Table
    {
        public string Name { get; set; }
        public string ClusteredIdName { get; set; }
        public int ClusteredIdNextValue { get; set; }
        public Dictionary<int, Dictionary<string, string>> Records { get; set; }
    }
}
