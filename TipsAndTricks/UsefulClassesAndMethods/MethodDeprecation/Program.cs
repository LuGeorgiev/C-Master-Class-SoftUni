namespace MethodDeprecation
{
    public static class Program
    {
        public static void Main()
        {
            var xmlReaderFactory = new XmlReaderFactory();
            xmlReaderFactory.CreateXmlReader();

            // Compilation warning:
            // xmlReaderFactory.CreateXml();

            // Compilation error:
            // xmlReaderFactory.Create();
        }
    }
}