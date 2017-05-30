using System;

namespace Experiments.Core.Utils
{
    public static class Validator
    {
        public static void IsStringNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value.Trim()))
            {
                throw new ArgumentOutOfRangeException($"{nameof(value)} cannot be empty or whitespace");
            }
        }

        public static void IsBiggerThan<T>(T value, T minRequired)
            where T : IComparable<T>
        {
            if (value.CompareTo(minRequired) < 1)
            {
                throw new ArgumentException($"{nameof(value)} should be bigger than {minRequired}");
            }
        }
    }
}