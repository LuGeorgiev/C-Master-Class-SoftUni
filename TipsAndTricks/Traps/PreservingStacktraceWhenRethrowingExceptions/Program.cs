namespace PreservingStacktraceWhenRethrowingExceptions
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            // Notice TargetSite and StackTrace
            var exceptionThrower = new ExceptionThrower();
            try
            {
                exceptionThrower.WithoutStacktrace();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                exceptionThrower.WithStacktrace();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                exceptionThrower.WithNewException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}