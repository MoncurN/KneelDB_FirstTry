using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.Core
{
    using System;
    using System.IO;
    using System.Text.Json;

    namespace KneelDB.Core
    {
        public class Storage
        {
            public const string DefaultTableName = "Default";
            public const string DefaultDatabaseName = "Default";

            public static string Read(string tableName, string databaseName)
            {
                string json = "";
                var path = Config.BasePath + "/" + databaseName;
                var fullPath = path + "/" + tableName + ".json";

                if (File.Exists(fullPath))
                {
                    json = File.ReadAllText(fullPath);
                }

                return json;
            }

            public static void Write(string json, Location location)
            {
                var path = Config.BasePath + "/" + location.DatabaseName;
                var fullPath = path + "/" + location.TableName + ".json";

                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(path);
                }

                File.WriteAllText(fullPath, json);
            }
        }
    }
}
