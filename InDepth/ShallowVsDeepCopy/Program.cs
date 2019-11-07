using System;

namespace ShallowVsDeepCopy
{
    public struct Shoe
    {
        public string Color;
    }

    public class Dude
    {
        public string Name;
        public Shoe RightShoe;
        public Shoe LeftShoe;

        public Dude CopyDude()
        {
            Dude newPerson = new Dude();
            newPerson.Name = Name;
            newPerson.LeftShoe = LeftShoe;
            newPerson.RightShoe = RightShoe;

            return newPerson;
        }

        public override string ToString()
        {
            return (Name + " : Dude!, I have a " + RightShoe.Color + " shoe on my right foot, and a " + LeftShoe.Color + " on my left foot.");
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            var dude = new Dude();
            var redShoe = new Shoe() { Color = "red" };
            var blueShoe = new Shoe() { Color = "blue" };
            dude.LeftShoe = redShoe;
            dude.RightShoe = blueShoe;

            var dude2 = dude.CopyDude();
            dude2.LeftShoe.Color = "zelen";

            // Change Shoe from struct to class and observe thе differences

            Console.WriteLine(dude);
            Console.WriteLine(dude2);
        }
    }
}
