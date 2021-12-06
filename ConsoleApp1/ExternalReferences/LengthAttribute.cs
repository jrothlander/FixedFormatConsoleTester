using System;

namespace Extensions
{
    public class LengthAttribute : Attribute
    {
        public LengthAttribute(int value) { Value = value; }
        public int Value { get; }
    }
}
