using System;
using System.IO;
using System.Text.Json;

namespace KneelDB.Core
{
    public class Storage 
    {
        public const string DefaultTableName = "Default";
        public const string DefaultDatabaseName = "Default";

        public static Table GetTable(string tableName=DefaultTableName, string databaseName=DefaultDatabaseName) {
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

        public static void SaveTable(Table table, string tableName=DefaultTableName, string databaseName=DefaultDatabaseName) 
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(table, options);

            Write(json, tableName, databaseName);
        }

        private static string Read(string tableName, string databaseName) 
        {
            string json = "";
            var path = Config.BasePath + "/" + databaseName ;
            var fullPath = path + "/" + tableName + ".json";

            if (File.Exists(fullPath)) {
                json = File.ReadAllText(fullPath);
            }

            return json;
        }

        private static void Write(string json, string tableName, string databaseName) {
            var path = Config.BasePath + "/" + databaseName ;
            var fullPath = path + "/" + tableName + ".json";

            if (!Directory.Exists(fullPath)) {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(fullPath, json);
        }
    }
}