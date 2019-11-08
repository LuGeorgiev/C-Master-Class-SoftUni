namespace CombinableEnumValues
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var bottomRightMargin = Margins.Bottom | Margins.Right;
            var topLeftMargin = Margins.Top | Margins.Left;
                       

            // Getting information
            Console.WriteLine("bottomRightMargin string value: {0}", bottomRightMargin);
            Console.WriteLine("bottomRightMargin integer value: {0}", (int)bottomRightMargin);
            Console.WriteLine("bottomRightMargin == Margins.Bottom: {0}", bottomRightMargin == Margins.Bottom);
            Console.WriteLine(
                "bottomRightMargin has flag Margins.Bottom: {0}",
                bottomRightMargin.HasFlag(Margins.Bottom)); // Equivalent to (bottomRightMargin & Margins.Bottom) != 0

            // Combining combinations
            Console.WriteLine("bottomRightMargin and topLeftMargin: {0}", bottomRightMargin | topLeftMargin);

            // Toggling values
            bottomRightMargin ^= Margins.Bottom;
            Console.WriteLine("bottomRightMargin ^= Margins.Bottom => {0}", bottomRightMargin);
            bottomRightMargin ^= Margins.Bottom;
            Console.WriteLine("bottomRightMargin ^= Margins.Bottom => {0}", bottomRightMargin);
        }
    }
}