using System.Collections.Generic;

namespace KneelDB.Core
{
    public class ValueType
    {
        public static readonly string DateTime = "DateTime";
        public static readonly string Decimal = "Decimal";
        public static readonly string Double = "Double";
        public static readonly string Float = "Float";
        public static readonly string Int16 = "Int16";
        public static readonly string Int32 = "Int32";
        public static readonly string Int64 = "Int64";
        public static readonly string String = "String";

        public static bool IsValidValueType(string type)
        {
            if (type == ValueType.DateTime ||
                type == ValueType.Decimal ||
                type == ValueType.Double ||
                type == ValueType.Float ||
                type == ValueType.Int16 ||
                type == ValueType.Int32 ||
                type == ValueType.Int64 ||
                type == ValueType.String)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //public enum ValueType
    //{
    //    DateTime,
    //    Decimal,
    //    Double,
    //    Float,
    //    Int16,
    //    Int32,
    //    Int64,
    //    String
    //}
}