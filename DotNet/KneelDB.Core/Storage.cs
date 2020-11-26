using System;
using System.IO;
using System.Text.Json;

namespace KneelDB 
{
    public class Storage 
    {
        public Table GetTable(string tableName = "Blah", string databaseName = "Blah") {
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

        public void SaveTable(Table table, string tableName="Blah", string databaseName="Blah") 
        {
            var json = JsonSerializer.Serialize(table);

            Write(json, tableName, databaseName);
        }

        private string Read(string tableName, string databaseName) 
        {
            string json = "";
            var path = @".\" + databaseName ;
            var fullPath = path + @"\" + tableName + ".json";

            if (File.Exists(fullPath)) {
                json = File.ReadAllText(fullPath);
            }

            return json;
        }

        private void Write(string json, string tableName, string databaseName) {
            var path = @".\" + databaseName ;
            var fullPath = path + @"\" + tableName + ".json";

            if (!Directory.Exists(fullPath)) {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(fullPath, json);
        }
    }
}