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

        public int Insert<T>(T values) 
        {
            var props = values.GetType().GetProperties();
            
            foreach (var prop in props) {
                Console.WriteLine(prop.Name + ":" + prop.GetValue(values));
            }

            return 1;
        }
    }
}