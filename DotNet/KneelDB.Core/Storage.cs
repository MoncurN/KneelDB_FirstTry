using Newtonsoft.Json;
using System.Collections.Generic;

namespace KneelDB.Core
{
    public class Storage
    {
        public static Table GetTable(Location location)
        {
            Table table;

            var json = StorageDiskConnector.Read(location);

            if (json == "")
            {
                table = new Table
                {
                    Name = location.TableName,
                    ClusteredIdName = location.TableName + "Id",
                    ClusteredIdNextValue = 1,
                    Records = new Dictionary<int, Dictionary<string, string>>()
                };
            }
            else
            {
                table = JsonConvert.DeserializeObject<Table>(json);
            }

            return table;
        }

        public static void UpdateTable(Table table, Location location)
        {
            var json = JsonConvert.SerializeObject(table, Formatting.Indented);

            StorageDiskConnector.Write(json, location);
        }
    }
}
