using System.IO;

namespace KneelDB 
{
    public class Storage 
    {
        public string Read() 
        {
            var json = Read("Default", "Default");

            return json;
        }

        public string Read(string tableName) 
        {
            var json = Read(tableName, "Default");

            return json;
        }

        public string Read(string tableName, string databaseName) 
        {
            string json = "";
            var path = @".\" + databaseName + @"\" + tableName + ".json";

            if (File.Exists(path)) {
                json = File.ReadAllText(path);
            }

            return json;
        }
    }
}