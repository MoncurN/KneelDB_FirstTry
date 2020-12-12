using System;
using System.Collections.Generic;
using System.Dynamic;
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

        public int Insert(dynamic values)
        {
            var props = values.GetType().GetProperties();

            Dictionary<string, Value> record = new Dictionary<string, Value>();

            foreach (var prop in props)
            {
                Value value = null;
                switch (prop.PropertyType.FullName)
                {
                    case "System.DateTime":
                        value = new Value(ValueType.DateTime, prop.GetValue(values));
                        record.Add(prop.Name, value);
                        break;
                    case "System.Decimal":
                        value = new Value(ValueType.Decimal, prop.GetValue(values));
                        record.Add(prop.Name, value);
                        break;
                    case "System.Double":
                        value = new Value(ValueType.Double, prop.GetValue(values));
                        record.Add(prop.Name, value);
                        break;
                    case "System.Int16":
                        value = new Value(ValueType.Int16, prop.GetValue(values));
                        record.Add(prop.Name, value);
                        break;
                    case "System.Int32":
                        value = new Value(ValueType.Int32, prop.GetValue(values));
                        record.Add(prop.Name, value);
                        break;
                    case "System.Int64":
                        value = new Value(ValueType.Int64, prop.GetValue(values));
                        record.Add(prop.Name, value);
                        break;
                    case "System.String":
                        value = new Value(ValueType.String, prop.GetValue(values));
                        record.Add(prop.Name, value);
                        break;
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





            dynamic expand = new ExpandoObject();
            expand.Blah = 1;
            var thing = (dynamic)expand;






            // For each record in the database
            foreach (var record in table.Records)
            {
                var result = new T();

                var keyMatchFound = false;

                // For each property in T
                foreach (var prop in tProps) 
                {
                    // If the record contains the property
                    if (record.Value.ContainsKey(prop.Name))
                    {
                        keyMatchFound = true;
                        // Attempt to cast prop to the desired type
                        switch (prop.PropertyType.FullName)
                        {
                            case "System.DateTime":
                                var dateTimeValue = record.Value.GetValueOrDefault(prop.Name).ToString();
                                DateTime dateTimeParsed;
                                if (DateTime.TryParse(dateTimeValue, out dateTimeParsed))
                                {
                                    prop.SetValue(result, dateTimeParsed);
                                }
                                break;
                            case "System.Decimal":
                                var decimalValue = record.Value.GetValueOrDefault(prop.Name).ToString();
                                decimal decimalParsed;
                                if (Decimal.TryParse(decimalValue, out decimalParsed))
                                {
                                    prop.SetValue(result, decimalParsed);
                                }
                                break;
                            case "System.Double":
                                var doubleValue = record.Value.GetValueOrDefault(prop.Name).ToString();
                                double doubleParsed;
                                if (Double.TryParse(doubleValue, out doubleParsed))
                                {
                                    prop.SetValue(result, doubleParsed);
                                }
                                break;
                            case "System.Single":
                                var singleValue = record.Value.GetValueOrDefault(prop.Name).ToString();
                                float singleParsed;
                                if (Single.TryParse(singleValue, out singleParsed))
                                {
                                    prop.SetValue(result, singleParsed);
                                }
                                break;
                            case "System.Int16":
                                var int16Value = record.Value.GetValueOrDefault(prop.Name).ToString();
                                Int16 int16Parsed;
                                if (Int16.TryParse(int16Value, out int16Parsed))
                                {
                                    prop.SetValue(result, int16Parsed);
                                }
                                break;
                            case "System.Int32":
                                var int32Value = record.Value.GetValueOrDefault(prop.Name).ToString();
                                Int32 int32Parsed;
                                if (Int32.TryParse(int32Value, out int32Parsed))
                                {
                                    prop.SetValue(result, int32Parsed);
                                }
                                break;
                            case "System.Int64":
                                var int64Value = record.Value.GetValueOrDefault(prop.Name).ToString();
                                Int64 int64Parsed;
                                if (Int64.TryParse(int64Value, out int64Parsed))
                                {
                                    prop.SetValue(result, int64Parsed);
                                }
                                break;
                            case "System.String":
                                var stringValue = record.Value.GetValueOrDefault(prop.Name).ToString();
                                prop.SetValue(result, stringValue);
                                break;
                        }
                    }
                }

                if (keyMatchFound)
                {
                    results.Add(result);
                }
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