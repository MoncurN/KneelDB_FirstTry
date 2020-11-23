using System.Collections.Generic;

namespace KneelDB 
{
    public class Table {
        public Table () {
            NextId = 1;
            Records = new List<Dictionary<string, string>>();
        }

        public int NextId { get; set; }

        public List<Dictionary<string,string>> Records { get; set; }
    }
}