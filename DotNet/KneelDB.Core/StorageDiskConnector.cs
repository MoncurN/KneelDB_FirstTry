using System.IO;

namespace KneelDB.Core
{
    public class StorageDiskConnector
    {
        public static string Read(Location location)
        {
            string json = "";
            var path = Config.BasePath + "/" + location.DatabaseName;
            var fullPath = path + "/" + location.TableName + ".json";

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
