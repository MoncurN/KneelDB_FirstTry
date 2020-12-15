using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.Core
{
    public class Processor
    {
        public static int Insert(Dictionary<string, string> record, string into = null)
        {
            var location = new Location(into);

            var table = GetTable(location);

            CheckColumns(record, table);

            var id = table.ClusteredIdNextValue;
            record.Add(table.ClusteredIdName, id.ToString());
            table.Records.Add(id, record);

            table.ClusteredIdNextValue++;

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.WriteAsString,
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(table, jsonSerializerOptions);

            Storage.Write(json, location);

            return id;
        }
    }
}
