using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneelDB.Core
{
    public class DataType
    {
        public const string Any = "Any";
        public const string Boolean = "Boolean";
        public const string DateTime = "DateTime";
        public const string Decimal = "Decimal";
        public const string Double = "Double";
        public const string Float = "Float";
        public const string Int16 = "Int16";
        public const string Int32 = "Int32";
        public const string Int64 = "Int64";
        public const string String = "String";

        public static bool IsValidValueType(string type)
        {
            if (type == DataType.Any || 
                type == DataType.Boolean || 
                type == DataType.DateTime ||
                type == DataType.Decimal ||
                type == DataType.Double ||
                type == DataType.Float ||
                type == DataType.Int16 ||
                type == DataType.Int32 ||
                type == DataType.Int64 ||
                type == DataType.String)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
