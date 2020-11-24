using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using Newtonsoft.Json;

namespace KneelDB
{
    public class Query {
        public string TableName { get; set; }
        public string DatabaseName { get; set; }

        public Query() {
            TableName = "Default";
            DatabaseName = "Default";
        }

        public Query(string tableName) {
            TableName = tableName;
            DatabaseName = "Default";
        }

        public Query(string tableName, string databaseName) {
            TableName = tableName;
            DatabaseName = databaseName;
        }

        public int InsertWithSerialization<T>(T values) 
        {
            var json = JsonConvert.SerializeObject(values);

            var dictionary = JsonConvert.DeserializeObject<Dictionary<string,string>>(json);

            var jsonAgain = JsonConvert.SerializeObject(dictionary);

            Console.WriteLine(jsonAgain);

            T final = JsonConvert.DeserializeObject<T>(jsonAgain);

            return 1;
        }

        public int Insert<T>(T values) 
        {
            var t = typeof(T);

            foreach (var prop in t.GetProperties()) {
                Console.WriteLine(prop.Name + ":" + prop.GetValue(values));
            }

            return 1;
        }

        public int Insert(Dictionary<string, string> values) 
        {
            Storage storage = new Storage();

            var table = storage.Read(TableName, DatabaseName);

            throw new NotImplementedException();
        }
    }
}