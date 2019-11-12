
namespace Demo
{
    using System;
    using System.Linq.Expressions;

    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog
            {
                Name = "Pesho"
            };
            dog.SayBau(32);

            Func<Dog, string> func = doggy => doggy.SayBau(12);

            var result = func(new Dog());
            Console.WriteLine(result);

            //Expression in non-invocalbel
            Expression<Func<Dog, string>> expr = t => t.SayBau(16);
            var body = expr.Body;
            Console.WriteLine(body);
            var parameters = expr.Parameters;
            foreach (var param in parameters)
            {
                Console.WriteLine(param.Name);
                Console.WriteLine(param.Type.Name);
            }
        }
    }
}
