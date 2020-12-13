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
        public string TableName { get; set; }
        public string DatabaseName { get; set; }

        public Processor()
        {
            TableName = "Default";
            DatabaseName = "Default";
        }

        public Processor(string tableName)
        {
            TableName = tableName;
            DatabaseName = "Default";
        }

        public Processor(string tableName, string databaseName)
        {
            TableName = tableName;
            DatabaseName = databaseName;
        }

        private Table GetTable()
        {
            Table table;

            var json = Storage.Read(TableName, DatabaseName);

            if (json == "")
            {
                table = new Table();
                table.Name = TableName;
                table.ClusteredIdName = TableName + "Id";
                table.ClusteredIdNextValue = 1;
                table.Columns = new List<Column>();
                table.Records = new Dictionary<int, Dictionary<string, string>>();
            }
            else
            {
                table = JsonSerializer.Deserialize<Table>(json);
            }

            return table;
        }

            public int Insert(dynamic values, InsertOptionNewColumns insertOptionNewColumns = InsertOptionNewColumns.IgnoreNewColumns)
        {
            var props = values.GetType().GetProperties();

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.NumberHandling = JsonNumberHandling.WriteAsString;

            var json = JsonSerializer.Serialize(values, jsonSerializerOptions);

            throw new NotImplementedException();
        }


        public int Insert(Dictionary<string, string> record, InsertOptionNewColumns insertOptionNewColumns = InsertOptionNewColumns.IgnoreNewColumns)
        {
            var table = GetTable();

            // Make sure Insert doesn't have a value for the Clustered Id
            if (record.ContainsKey(table.ClusteredIdName))
            {
                throw new Exception($"You cannot set property {Config.ClusteredIdName}.  It is auto-populated.");
            }

            // Check all of the properties in the record
            foreach (var kv in record)
            {
                var column = table.Columns.FirstOrDefault(c => c.Name == kv.Key);

                // If the Column does not exist yet, add it (with default type of "Any")
                if (column == null)
                {
                    if (insertOptionNewColumns == InsertOptionNewColumns.AddNewColumns) 
                    {
                        column = new Column { Name = kv.Key, DataType = DataType.Any };
                        table.Columns.Add(column);
                    }
                    else if (insertOptionNewColumns == InsertOptionNewColumns.ErrorOnNewColumn)
                    {
                        throw new ArgumentException($"Column {")
                    }
                }

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
            }

            var id = table.ClusteredIdNextValue;
            record.Add(table.ClusteredIdName, id.ToString());
            table.Records.Add(id, record);

            table.ClusteredIdNextValue++;

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.NumberHandling = JsonNumberHandling.WriteAsString;
            jsonSerializerOptions.WriteIndented = true;

            var json = JsonSerializer.Serialize(table, jsonSerializerOptions);

            Storage.Write(json, TableName, DatabaseName);

            return id;
        }
    }
}
