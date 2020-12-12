using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.Core
{
    public class Table
    {
        public Table ()
        {
            Name = "Default";
            ClusteredIdName = Name + "Id";
            ClusteredIdNextValue = 1;
        }

        public Table (string name)
        {
            Name = name;
            ClusteredIdName = Name + "Id";
            ClusteredIdNextValue = 1;
        }

        public Table (string name, string clusteredIdName)
        {
            Name = name;
            ClusteredIdName = clusteredIdName;
            ClusteredIdNextValue = 1;
        }

        public string Name { get; }
        public string ClusteredIdName { get; }
        public int ClusteredIdNextValue { get; }
        public List<Column> Columns { get; set; }
        public Dictionary<int, Dictionary<string,string>> Records { get; set; }

        public int Insert(Dictionary<string, string> record)
        {
            // Make sure Insert doesn't have a
            if (record.ContainsKey(ClusteredIdName))
            {
                throw new Exception($"You cannot set property {Config.ClusteredIdName}.  It is auto-populated.");
            }

            foreach (var kv in record)
            {
                var column = Columns.FirstOrDefault(c => c.Name == kv.Key);

                if (column == null)
                {
                    column = new Column { Name = kv.Key, DataType = DataType.Any };
                    Columns.Add(column);
                }

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

            throw new NotImplementedException();
        }
    }
}
