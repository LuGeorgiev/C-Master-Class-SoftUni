using System.Threading.Tasks;

namespace MyCustomHttpServer
{
    public interface IHttpServer
    {
        void Start();

        void Stop();
    }
}