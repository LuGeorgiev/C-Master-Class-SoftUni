namespace Demo
{
    public class Dog
    {
        public Dog()
        {

        }

        public Dog(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public Owner Owner { get; set; }

        public string SayBau(int number)
        {
            return $"Bauu {number} times!";
        }
    }
}
