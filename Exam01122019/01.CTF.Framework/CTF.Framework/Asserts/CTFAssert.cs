namespace CTF.Framework.Asserts
{
    using CTF.Framework.Exceptions;
    using System;

    // ReSharper disable once InconsistentNaming
    public abstract class CTFAssert        
    {
        public static void AreEqual(object a, object b)
        {
            if (! object.ReferenceEquals(a, b))
            {
                throw new TestException();
            }
        }

        public static void AreNotEqual(object a, object b)
        {
            if (object.ReferenceEquals(a, b))
            {
                throw new TestException();
            }            
        }

        public static void Throws<T>(Func<bool> condition)
            where T: Exception
        {            
            if (!condition.Invoke())
            {
                throw new TestException();
            }
        }
    }
}
