namespace Demo
{
    public class Dog
    {
        public Dog()
        {
            PrivateProperty = "Most Important value";
        }

        public Dog(string name)
        {
            Name = name;
            PrivateProperty = "Very Important value";
        }
        public string Name { get; set; }

        public Owner Owner { get; set; }

        private string PrivateProperty { get; set; }

        public string SayBau(int number)
        {
            return $"Bauu {number} times!";
        }
    }
}
