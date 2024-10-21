namespace SingleLog.Utilities
{
    public abstract class Enumeration
    {
        public string Name { get; }
        public int Value { get; }

        public Enumeration(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public override string ToString() => Name;
        public static implicit operator int(Enumeration value) => value.Value;
        public static implicit operator long(Enumeration value) => value.Value;
        public static implicit operator string(Enumeration value) => value.Name;
        public static implicit operator byte(Enumeration value) => Convert.ToByte(value.Value);
    }
}
