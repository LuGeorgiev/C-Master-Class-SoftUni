using System;
using System.Reflection;
using Demo;

namespace Dynamic
{
    class Program
    {

        static void Main(string[] args)
        {
            dynamic dinamiclDog = new Dog();
            //will throw
            //Console.WriteLine(dinamiclDog.SayBau("Test"));
            
            Console.WriteLine(dinamiclDog.SayBau(13));

            var property = typeof(Dog).GetProperty("PrivateProperty", BindingFlags.Instance | BindingFlags.NonPublic);
            var propValue = property.GetValue(new Dog("Ivan")) as string;
            Console.WriteLine(propValue);

            dynamic someDin = new ExposedObject(new Dog());
            someDin.Wathever();
            someDin.Jump();

            var doggy = new Dog();
            dynamic someDog = doggy.Exposed();

            var value = someDog.PrivateProperty;
            Console.WriteLine(value);
        }
    }
}
