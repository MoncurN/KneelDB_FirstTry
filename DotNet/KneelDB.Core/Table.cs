using System;
using System.Collections.Generic;

namespace KneelDB.Core
{
    public class Table {
        public Table () {
            NextId = 1;
            Records = new Dictionary<int, Dictionary<string,dynamic>>();
        }

        public int NextId { get; set; }

        public Dictionary<int, Dictionary<string,dynamic>> Records { get; set; }
        //public List<Dictionary<string,dynamic>> Records { get; set; }

        public int Insert(Dictionary<string,dynamic> record) 
        {
            if (record.ContainsKey(Config.AutoIdName)) {
                throw new Exception($"You cannot set property {Config.AutoIdName}.  It is auto-populated.");
            }

            var id = NextId;

            record.Add(Config.AutoIdName, id);
            Records.Add(id, record);

            NextId++;

            return id;
        }
    }
}