using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Hello();
        }

        static async Task<string> Hello()
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("before");

            await client.GetAsync( "file");

            Console.WriteLine("After");
            return "foo";
        }
    }
}
