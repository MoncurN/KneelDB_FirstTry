using KneelDB.Core.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.Core
{
    public class InsertProcessor
    {
        public static int Insert(Dictionary<string, string> values, string into = "")
        {
            var location = new Location(into);

            var table = Storage.GetTable(location);

            CheckColumns(values, table);

            var id = table.ClusteredIdNextValue;
            values.Add(table.ClusteredIdName, id.ToString());
            table.Records.Add(id, values);

            table.ClusteredIdNextValue++;

            Storage.UpdateTable(table, location);

            return id;
        }

        public static int Insert(dynamic values, string into = "")
        {

        }

        private static void CheckColumns(Dictionary<string, string> values, Table table)
        {
            // Make sure Insert doesn't have a value for the Clustered Id
            if (values.ContainsKey(table.ClusteredIdName))
            {
                throw new Exception($"You cannot set property {table.ClusteredIdName} for table {table.Name}.  It is an auto-populated Clustered Id.");
            }

            // Make sure record has all required columns
            foreach (var r in table.Columns.Where(c => c.Required == true).ToList())
            {
                if (!values.GetType().GetProperties().Any(p => p.Name == r.Name))
                {
                    throw new ArgumentException($"The record does not include {r.Name}, which is a required column.");
                }
            }

            var hasValue = false;

            // Check each property
            foreach (var kv in values)
            {
                var column = table.Columns.FirstOrDefault(c => c.Name == kv.Key);

                // If the Column does not exist yet
                if (column == null)
                {
                    // If the New Columns Query Option is: Add, then add it
                    if (Config.QueryOptionNewColumns == QueryOptionNewColumns.Add)
                    {
                        column = new Column { Name = kv.Key, DataType = DataType.Any };
                        table.Columns.Add(column);
                    }
                    // If the New Columns Query Option is Throw Exception, then throw one
                    else if (Config.QueryOptionNewColumns == QueryOptionNewColumns.ThrowException)
                    {
                        throw new ArgumentException($"Column {kv.Key} does not exist, and ");
                    }
                    // This conditional should not occur; provided for completeness
                    else if (Config.QueryOptionNewColumns != QueryOptionNewColumns.Ignore)
                    {
                        throw new NotImplementedException($"Error handling new column name.  Query Option not permitted.");
                    }
                }

                // Check the column's data type
                if (column != null)
                {
                    // Check if the value in record matches the column's data type
                    switch (column.DataType)
                    {
                        case DataType.Boolean:
                            Boolean booleanParsed;
                            if (!Boolean.TryParse(kv.Value, out booleanParsed))
                            {
                                throw new ArgumentException($"Property {kv.Key} does not match type {column.DataType}");
                            }
                            break;
                        case DataType.DateTime:
                            DateTime dateTimeParsed;
                            if (!DateTime.TryParse(kv.Value, out dateTimeParsed))
                            {
                                throw new ArgumentException($"Property {kv.Key} does not match type {column.DataType}");
                            }
                            break;
                        case DataType.Decimal:
                            Decimal decimalParsed;
                            if (!Decimal.TryParse(kv.Value, out decimalParsed))
                            {
                                throw new ArgumentException($"Property {kv.Key} does not match type {column.DataType}");
                            }
                            break;
                        case DataType.Double:
                            Double doubleParsed;
                            if (!Double.TryParse(kv.Value, out doubleParsed))
                            {
                                throw new ArgumentException($"Property {kv.Key} does not match type {column.DataType}");
                            }
                            break;
                        case DataType.Float:
                            float floatParsed;
                            if (!float.TryParse(kv.Value, out floatParsed))
                            {
                                throw new ArgumentException($"Property {kv.Key} does not match type {column.DataType}");
                            }
                            break;
                        case DataType.Int16:
                            Int16 int16Parsed;
                            if (!Int16.TryParse(kv.Value, out int16Parsed))
                            {
                                throw new ArgumentException($"Property {kv.Key} does not match type {column.DataType}");
                            }
                            break;
                        case DataType.Int32:
                            Int32 int32Parsed;
                            if (!Int32.TryParse(kv.Value, out int32Parsed))
                            {
                                throw new ArgumentException($"Property {kv.Key} does not match type {column.DataType}");
                            }
                            break;
                        case DataType.Int64:
                            Int64 int64Parsed;
                            if (!Int64.TryParse(kv.Value, out int64Parsed))
                            {
                                throw new ArgumentException($"Property {kv.Key} does not match type {column.DataType}");
                            }
                            break;
                        default:
                            // DataType == Any or String
                            // Don't need to do anything
                            break;
                    }

                    hasValue = true;
                }
            }

            if (!hasValue)
            {
                throw new ArgumentException("No columns were found that could be written to the database.");
            }
        }
    }
}
