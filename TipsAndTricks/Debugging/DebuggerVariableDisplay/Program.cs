namespace DebuggerVariableDisplay
{
    using System.Collections.Generic;

    public static class Program
    {
        public static void Main()
        {
            // Set breakpoints and observe debugging info of the following variables
            var student = new Student("John", "Doe");

            var studentWithToStringMethod = new StudentWithToStringMethod("John", "Doe");

            var studentWithDebuggerDisplayAttribute = new StudentWithDebuggerDisplayAttribute("John", "Doe");

            var studentWithDebuggerBrowsableAttribute = new StudentWithDebuggerBrowsableAttribute(
                "John",
                "Doe",
                new List<int> { 3, 3, 6, 6 });
        }
    }
}
