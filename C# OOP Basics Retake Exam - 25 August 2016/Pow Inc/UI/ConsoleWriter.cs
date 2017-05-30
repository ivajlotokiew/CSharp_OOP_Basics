namespace ReallySimpleEngine.UI
{
    using System;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Print(string msg, params object[] args)
        {
            Console.WriteLine(msg, args);
        }
    }
}