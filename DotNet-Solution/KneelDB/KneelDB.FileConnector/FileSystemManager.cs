using KneelDB.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.Json.Serialization;

namespace KneelDB.FileConnector
{
    public class FileSystemManager
    {
        public Database Read(string databaseName, string tableName)
        {
            if (!Directory.Exists(databaseName))
            {
                Directory.CreateDirectory(databaseName);
            }

            Database database = null;

            if (!File.Exists(databaseName + @"\" + tableName + @".json"))
            {
                database = new Database();
            }
            else
            {
                var json = File.ReadAllText(databaseName + @"\" + tableName + @".json");
                database = JsonConvert.DeserializeObject<Database>(json);
            }

            return database;
        }

        public void Write(Database database)
        {

        }
    }
}
