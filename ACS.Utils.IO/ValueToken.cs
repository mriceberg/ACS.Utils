namespace ACS.Utils.IO
{
    public class ValueToken<T>
    {
        public T Value { get; private set; }
        public ValueTokenFormatter<T> Formatter { get; private set; }

        public ValueToken(T value)
            : this(value, null)
        {
        }
        public ValueToken(T value, ValueTokenFormatter<T> formatter)
        {
            this.Value = value;
            this.Formatter = formatter;
        }

        public override string ToString() => (Formatter != null) ? Formatter.Format(Value) : Value.ToString();
    }
}
