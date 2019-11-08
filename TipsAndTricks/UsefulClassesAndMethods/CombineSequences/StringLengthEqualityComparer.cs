namespace CombineSequences
{
    using System.Collections.Generic;

    public class StringLengthEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Length == y.Length;
        }

        public int GetHashCode(string obj)
        {
            return obj.Length.GetHashCode();
        }
    }
}