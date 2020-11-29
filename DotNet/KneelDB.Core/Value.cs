namespace KneelDB.Core
{
    public class Value
    {
        public ValueType ValueType { get; set; }
        public dynamic Content { get; set; }

        public Value(ValueType valueType, dynamic content) {
            ValueType = valueType;
            Content = content;
        }
    }
}