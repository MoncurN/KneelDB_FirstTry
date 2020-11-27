using System;
using System.IO;
using System.Text.Json;

namespace KneelDB.Core
{
    public class Storage 
    {
        public const string DefaultTableName = "Default";
        public const string DefaultDatabaseName = "Default";

        public Table GetTable(string tableName=DefaultTableName, string databaseName=DefaultDatabaseName) {
            Table table;

            var json = Read(tableName, databaseName);

            if (json == "") {
                table = new Table();
            }
            else 
            {
                table = JsonSerializer.Deserialize<Table>(json);
            }

            return table;
        }

        public void SaveTable(Table table, string tableName=DefaultTableName, string databaseName=DefaultDatabaseName) 
        {
            var json = JsonSerializer.Serialize(table);

            Write(json, tableName, databaseName);
        }

        private string Read(string tableName, string databaseName) 
        {
            string json = "";
            var path = Config.BasePath + "/" + databaseName ;
            var fullPath = path + "/" + tableName + ".json";

            if (File.Exists(fullPath)) {
                json = File.ReadAllText(fullPath);
            }

            return json;
        }

        private void Write(string json, string tableName, string databaseName) {
            var path = Config.BasePath + "/" + databaseName ;
            var fullPath = path + "/" + tableName + ".json";

            if (!Directory.Exists(fullPath)) {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(fullPath, json);
        }
    }
}