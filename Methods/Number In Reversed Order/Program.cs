using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace _04.Problem
{
    public class Number
    {
        public decimal numb;

        public Number(decimal numb)
        {
            this.numb = numb;
        }

        public char[] ReverseNumbers(decimal number)
        {
            char[] symbols = number.ToString().ToCharArray();
            char[] reversedSymbols = symbols.Reverse().ToArray();
            return reversedSymbols;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            decimal input = decimal.Parse(Console.ReadLine());
            Number numb = new Number(input);
            char[] output = numb.ReverseNumbers(input);
            foreach (var VARIABLE in output)
            {
                Console.Write(VARIABLE);
            }

            Console.WriteLine();
        }
    }
}