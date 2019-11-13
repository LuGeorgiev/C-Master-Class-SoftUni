

namespace Dynamic
{
    public static class DynamicExtensions
    {
        public static ExposedObject Exposed(this object obj)
            => new ExposedObject(obj);
    }
}
