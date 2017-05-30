namespace ReallySimpleEngine.UI
{
    using System;
    using Contracts;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            string output = Console.ReadLine();

            return output;
        }
    }
}