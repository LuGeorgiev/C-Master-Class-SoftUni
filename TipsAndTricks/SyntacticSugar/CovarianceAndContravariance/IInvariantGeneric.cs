namespace CovarianceAndContravariance
{
    public interface IInvariantGeneric<T>
    {
        T Method(T parameter);
    }

    public class InvariantGeneric<T> : IInvariantGeneric<T>
    {
        public T Method(T parameter)
        {
            return parameter;
        }
    }
}