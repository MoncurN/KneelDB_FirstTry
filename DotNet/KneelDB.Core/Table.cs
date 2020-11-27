using System;
using System.Collections.Generic;

namespace KneelDB.Core
{
    public class Table {
        public Table () {
            NextId = 1;
            Records = new List<Dictionary<string,dynamic>>();
        }

        public int NextId { get; set; }

        public List<Dictionary<string,dynamic>> Records { get; set; }

        public int Insert(Dictionary<string,dynamic> record) 
        {
            if (record.ContainsKey("Id")) {
                throw new Exception("You cannot set Id.  It is auto-populated.");
                // TODO: Create a config variable that let's you set the Auto Id to be something else
            }

            var id = NextId;

            record.Add("Id", id);

            Records.Add(record);

            NextId++;

            return id;
        }
    }
}