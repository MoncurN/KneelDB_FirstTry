using System;
using System.Collections.Generic;

namespace KneelDB.Core
{
    public class Table {
        public Table () {
            NextClusteredId = 1;
            Records = new Dictionary<int, Dictionary<string,Value>>();
        }

        public int NextClusteredId { get; set; }

        public Dictionary<int, Dictionary<string,Value>> Records { get; set; }
        //public List<Dictionary<string,dynamic>> Records { get; set; }

        public int Insert(Dictionary<string,Value> record) 
        {
            if (record.ContainsKey(Config.ClusteredIdName)) {
                throw new Exception($"You cannot set property {Config.ClusteredIdName}.  It is auto-populated.");
            }

            var id = NextClusteredId;
            var clusteredId = new Value(ValueType.Int32, id);
            record.Add(Config.ClusteredIdName, clusteredId);
            Records.Add(NextClusteredId, record);

            NextClusteredId++;

            return id;
        }
    }
}