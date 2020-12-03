using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using Newtonsoft.Json;

namespace KneelDB.Core
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
            var type = values.GetType();
            var props = type.GetProperties();
            
            // Dictionary<string,Value> record = new Dictionary<string,Value>();
            // foreach (var prop in props) 
            // {
            //     var propertyType = prop.PropertyType.ToString();
            //     ValueType valueType;
            //     switch (propertyType)
            //     {
            //         case "DateTime":
            //             valueType = ValueType.DateTime;
            //             break;
            //         case "Decimal":
            //             valueType = ValueType.Decimal;
            //             break;
            //         case "Double":
            //             valueType = ValueType.Double;
            //             break;
            //         case "Int16":
            //             valueType = ValueType.Int16;
            //             break;
            //         case "Int32":
            //             valueType = ValueType.Int16;
            //             break;
            //         case "Int64":
            //             valueType = ValueType.Int16;
            //             break;
            //         case "String":
            //             valueType = ValueType.String;
            //             break;
            //         default:
            //             throw new Exception($"Type {prop.PropertyType.ToString()} not accepted.");
            //     }
            //     var value = new Value(valueType, prop.GetValue(values)); 
            //     record.Add(prop.Name, value);
            // }

            
            Dictionary<string,dynamic> record = new Dictionary<string,dynamic>();
            foreach (var prop in props) 
            {
                if (prop.PropertyType == typeof(String) || 
                    prop.PropertyType == typeof(DateTime) || 
                    prop.PropertyType == typeof(Int16) ||
                    prop.PropertyType == typeof(Int32) || 
                    prop.PropertyType == typeof(Int64) || 
                    prop.PropertyType == typeof(Decimal) || 
                    prop.PropertyType == typeof(Double) || 
                    prop.PropertyType == typeof(float)) 
                    {
                        record.Add(prop.Name, prop.GetValue(values));
                    }
            }

            var storage = new Storage();
            
            var table = storage.GetTable();
            
            var newId = table.Insert(record);
            
            storage.SaveTable(table);

            return newId;
        }

        public Table Select() 
        {
            var storage = new Storage();
            var table = storage.GetTable();
            return table;
        }

        public List<T> Select<T> () where T : new() {
            var storage = new Storage();
            var table = storage.GetTable();

            var tType = typeof(T);
            var tProps = tType.GetProperties();

            var results = new List<T>();

            // For each record in the database
            foreach (var record in table.Records)
            {
                // Create a new object of type T
                var result = new T();

                // For each property in type T
                foreach (var tProp in tProps)
                {
                    // Grab the property type
                    var propertyType = tProp.PropertyType;

                    // If the record has a key with that name
                    if (record.ContainsKey(tProp.Name)) {
                        // Attempt to cast to the desired property type
                        switch (propertyType.Name)
                        {
                            case "String":
                                var value = record.GetValueOrDefault(tProp.Name);
                                tProp.SetValue(result, tProp.Name);
                                break;
                        }
                    }




                    // switch (propertyType.Name)
                    // {
                    //     case "String":
                    //         var parsed = record.GetValueOrDefault(result)
                    //         break;
                    //     default:
                    //         throw new Exception()
                    //         break;
                    // }
                    // var resultProperty = result.GetType().GetProperty(tProp.Name);
                    // if (resultProperty != null) 
                    // {
                    //     resultProperty.SetValue(result, record.GetValueOrDefault(resultProperty.Name));
                    // }
                }

                results.Add(result);
            }

            return results;

            // foreach (var prop in props) {
            //     Console.WriteLine(prop.Name + ":" + prop.GetValue(values));
            // }
        }
    }
}