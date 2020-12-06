namespace KneelDB.Core
{
    public class Value
    {
        public string ValueType { get; set; }
        public dynamic Content { get; set; }

        public Value(string valueType, dynamic content) {
            ValueType = valueType;
            Content = content;
        }
    }
}