using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.Core
{
    public class Table
    {
        public Table()
        {
            Columns = new List<Column>();
            Records = new Dictionary<int, Dictionary<string, string>>();
        }

        public string Name { get; set; }
        public string ClusteredIdName { get; set; }
        public int ClusteredIdNextValue { get; set; }
        public List<Column> Columns { get; set; }
        public Dictionary<int, Dictionary<string, string>> Records { get; set; }
    }
}
