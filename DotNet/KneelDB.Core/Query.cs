using System;
using System.Collections.Generic;
using System.Linq;

namespace KneelDB.Core
{
    public class Query 
    {
        // Make sure some values were passed in
        public int Insert(Location location, Dictionary<string, string> values) {
            if (values == null || values.Count < 1) {
                throw new Exception("No values were included.");
            }
            
            // Make sure that none of the values is named "ID".  That is a special value, and will be maintained by the database.
            if (values.Keys.Any(k => k.ToUpper == "ID")) {
                throw new Exception("Cannot contain a value named \"ID\".");
            }

            
        }
    }
}