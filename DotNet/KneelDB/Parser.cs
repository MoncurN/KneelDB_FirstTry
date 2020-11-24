using System.Text.Json;

namespace KneelDB {
    public class Parser {
        public Table GetTable() {
            var table = GetTable("Default", "Default");

            return table;
        }

        public Table GetTable(string tableName) {
            var table = GetTable(tableName, "Default");

            return table;
        }

        public Table GetTable(string tableName, string databaseName) {
            var storage = new Storage();
            
            Table table;

            var json = storage.Read(tableName, databaseName);

            if (json == "") {
                table = new Table();
            }
            else 
            {
                table = JsonSerializer.Deserialize<Table>(json);
            }

            return table;
        }
    }
}