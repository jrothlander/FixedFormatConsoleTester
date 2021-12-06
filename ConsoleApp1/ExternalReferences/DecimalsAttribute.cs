using System;

namespace Extensions
{
    public class DecimalsAttribute : Attribute
    {
        public DecimalsAttribute(int value) { Value = value; }
        public int Value { get; }
    }
}
