using Demo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CreateExpression
{
    public class New<T>
        where T: class
    {
        public static Func<T> Instance = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
    }

    class Program
    {
        static void Main(string[] args)
        {

            // () => 42
            //42
            var constant = Expression.Constant(42);
            // () => 42
            var lambda = Expression.Lambda<Func<int>>(constant);
            var func = lambda.Compile();
            Console.WriteLine(func());

            // () => new Dog();
            var newExpression = Expression.New(typeof(Dog));
            var lambdaTwo = Expression.Lambda<Func<Dog>>(newExpression);
            var dogConstruction = lambdaTwo.Compile();
            var dog = dogConstruction();
            dog.Name = "Pit";
            Console.WriteLine(dog.SayBau(3));

            //Third approach
            var owner = New<Owner>.Instance();
            owner.FullName = "Mnogo qko";

            CompareInvokeAndExpressionCreation();
        }

        private static void CompareInvokeAndExpressionCreation()
        {
            var dogs = new List<Dog>();
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                dogs.Add(Activator.CreateInstance<Dog>());
            }
            Console.WriteLine(stopwatch.Elapsed);
            New<Dog>.Instance(); // This line is to compile teh Expression which is teh slowest operation
            stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                dogs.Add(New<Dog>.Instance());
            }
            Console.WriteLine(stopwatch.Elapsed);
            Console.WriteLine(dogs.Count);
        }
    }
}
