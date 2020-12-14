using KneelDB.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KneelDB.Core
{
    public class Processor
    {
        private static Table GetTable(Location location)
        {
            Table table;

            var json = Storage.Read(location.TableName, location.DatabaseName);

            if (json == "")
            {
                table = new Table
                {
                    Name = location.TableName,
                    ClusteredIdName = location.TableName + "Id",
                    ClusteredIdNextValue = 1,
                    Columns = new List<Column>(),
                    Records = new Dictionary<int, Dictionary<string, string>>()
                };
            }
            else
            {
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString,
                    WriteIndented = true
                };

                table = JsonSerializer.Deserialize<Table>(json, jsonSerializerOptions);
            }

            return table;
        }

        private static void CheckColumns(Dictionary<string,string> record, Table table)
        {
            var hasValue = false;

            // Make sure Insert doesn't have a value for the Clustered Id
            if (record.ContainsKey(table.ClusteredIdName))
            {
                throw new Exception($"You cannot set property {table.ClusteredIdName} for table {table.Name}.  It is an auto-populated Clustered Id.");
            }

            // Make sure record has all required columns
            foreach (var r in table.Columns.Where(c => c.Required == true).ToList())
            {
                if (!record.GetType().GetProperties().Any(p => p.Name == r.Name))
                {
                    throw new ArgumentException($"The record does not include {r.Name}, which is a required column.");
                }
            }

            foreach (var kv in record)
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

        public static int Insert(Dictionary<string, string> record, string into = null)
        {
            var location = new Location(into);

            var table = GetTable(location);

            CheckColumns(record, table);

            var id = table.ClusteredIdNextValue;
            record.Add(table.ClusteredIdName, id.ToString());
            table.Records.Add(id, record);

            table.ClusteredIdNextValue++;

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.WriteAsString,
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(table, jsonSerializerOptions);

            Storage.Write(json, location);

            return id;
        }

        public static int Insert(dynamic record, string into = null)
        {

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.WriteAsString
            };

            var json = JsonSerializer.Serialize(record, jsonSerializerOptions);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            var id = Insert(dictionary, into);
            return id;
        }

        public static List<Dictionary<string,string>> Select(string from = null)
        {
            var location = new Location(from);

            var table = GetTable(location);

            var records = new List<Dictionary<string, string>>();
            foreach (var record in table.Records)
            {
                records.Add(record.Value);
            }

            return records;

            throw new NotImplementedException();
        }
    }
}
