namespace Yield
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            foreach (var evenNumber in YieldNumbersGenerator.EvenNumbers(50, 60))
            {
                Console.WriteLine("Iterated number {0}", evenNumber);
            }
        }
    }
}