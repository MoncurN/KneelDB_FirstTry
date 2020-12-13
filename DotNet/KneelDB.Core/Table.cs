using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.Core
{
    // Needs to be a POCO, because DB needs to lock the file during read / write, and it's messy to manage that in this file
    public class Table
    {
        public string Name { get; set; }
        public string ClusteredIdName { get; }
        public int ClusteredIdNextValue { get; set; }
        public List<Column> Columns { get; set; }
        public Dictionary<int, Dictionary<string,string>> Records { get; set; }
    }
}