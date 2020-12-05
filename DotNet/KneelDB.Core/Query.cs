using System;
using System.Collections.Generic;
using System.Linq;
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
            var props = values.GetType().GetProperties();
            
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
                    prop.PropertyType == typeof(Single)) 
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


        public List<T> Select<T> () where T : new() 
        {
            var storage = new Storage();
            var table = storage.GetTable();

            var results = new List<T>();
            
            var tProps = typeof(T).GetProperties();

            // For each record in the database
            foreach (var record in table.Records)
            {
                var result = new T();




        //         // Create a new object of type T
        //         var result = new T();

        //         // For each property in type T
        //         foreach (var tProp in tProps)
        //         {
        //             // Grab the property type
        //             var propertyType = tProp.PropertyType;

        //             // If the record has a key with that name
        //             if (record.ContainsKey(tProp.Name)) {
        //                 // Attempt to cast to the desired property type
        //                 switch (propertyType.FullName)
        //                 {
        //                     case "System.DateTime":
        //                         var dateTimeValue = record.GetValueOrDefault(tProp.Name).ToString();
        //                         DateTime dateTimeParsed;
        //                         if (DateTime.TryParse(dateTimeValue, out dateTimeParsed))
        //                         {
        //                             tProp.SetValue(result, dateTimeParsed);
        //                         }
        //                         break;
        //                     case "System.Decimal":
        //                         var decimalValue = record.GetValueOrDefault(tProp.Name).ToString();
        //                         decimal decimalParsed;
        //                         if (Decimal.TryParse(decimalValue, out decimalParsed))
        //                         {
        //                             tProp.SetValue(result, decimalParsed);
        //                         }
        //                         break;
        //                     case "System.Double":
        //                         var doubleValue = record.GetValueOrDefault(tProp.Name).ToString();
        //                         double doubleParsed;
        //                         if (Double.TryParse(doubleValue, out doubleParsed))
        //                         {
        //                             tProp.SetValue(result, doubleParsed);
        //                         }
        //                         break;
        //                     case "System.Single":
        //                         var singleValue = record.GetValueOrDefault(tProp.Name).ToString();
        //                         float singleParsed;
        //                         if (Single.TryParse(singleValue, out singleParsed))
        //                         {
        //                             tProp.SetValue(result, singleParsed);
        //                         }
        //                         break;
        //                     case "System.Int16":
        //                         var int16Value = record.GetValueOrDefault(tProp.Name).ToString();
        //                         Int16 int16Parsed;
        //                         if (Int16.TryParse(int16Value, out int16Parsed))
        //                         {
        //                             tProp.SetValue(result, int16Parsed);
        //                         }
        //                         break;
        //                     case "System.Int32":
        //                         var int32Value = record.GetValueOrDefault(tProp.Name).ToString();
        //                         Int32 int32Parsed;
        //                         if (Int32.TryParse(int32Value, out int32Parsed))
        //                         {
        //                             tProp.SetValue(result, int32Parsed);
        //                         }
        //                         break;
        //                     case "System.Int64":
        //                         var int64Value = record.GetValueOrDefault(tProp.Name).ToString();
        //                         Int64 int64Parsed;
        //                         if (Int64.TryParse(int64Value, out int64Parsed))
        //                         {
        //                             tProp.SetValue(result, int64Parsed);
        //                         }
        //                         break;
        //                     case "System.String":
        //                         var stringValue = record.GetValueOrDefault(tProp.Name).ToString();
        //                         tProp.SetValue(result, stringValue);
        //                         break;
                            
        //                 }
        //             }
        //         }

        //         results.Add(result);
            }

            return results;
        }

        // public void Update<T>(T values) where T : new() 
        // {
        //     var idProp = values.GetType().GetProperty("Id");
        //     var id = idProp.GetValue(values);

        //     //var id = values.GetValueOrDefault(idProp.Name).ToString();
        //     //var id = values.GetType().GetProperty("Id").GetValue(T);
        //     //Console.WriteLine(id);
            
        //     // Get the Id
        //     // int id = default(int);
        //     // var valuesType = values.GetType();
        //     // var idProperty = valuesType.GetProperty("Id");
        //     // if (idProperty == null || idProperty.PropertyType != typeof(Int32)) {
        //     //     throw new Exception("No Id property specified");
        //     // }

        //     // id = values.GetValueOrDefault("Id");

        //     //var table = Select<T>();
             
            
        //     // Make sure the Id is found within the table
        //     // If not, it's not an error, just return to caller
        //     //var record = table.Records.FirstOrDefault(r => true);
        //     // var blah = record["Id"];
        //     // var thing = blah.Get
        //     var i = 1;
        // }
    }
}