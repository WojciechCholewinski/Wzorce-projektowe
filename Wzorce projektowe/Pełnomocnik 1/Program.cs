using System;

namespace Proxy
{

    public interface IClient
    {
        string GetData();
    }

    public class RealClient : IClient
    {
        private string Data { get; set; }

        public RealClient()
        {
            Console.WriteLine("RealClient: Initialized");
            Data = "WSEI data";
        }

        public string GetData()
        {
            return Data;
        }
    }

    public class ProxyClient : IClient
    {
        private string _password = "dobrehaslo";
        private RealClient client = null;
        private bool _authenticated;

        public ProxyClient(string password)
        {
            if (password == _password)
            {
                Console.WriteLine("ProxyClient: Initialized");
                _authenticated = true;
                client = new RealClient();
            }
            else
            {
                _authenticated = false;
                Console.WriteLine("ProxyClient: Access denied");
            }
        }

        public string GetData()
        {
            if (_authenticated)
            {
                return "Data from Proxy Client = " + client.GetData();
            }
            return String.Empty;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProxyClient proxy1 = new ProxyClient("zlehaslo");
            Console.WriteLine(proxy1.GetData());

            ProxyClient proxy3 = new ProxyClient("ScisleTajne1@3$");
            Console.WriteLine(proxy3.GetData());

            ProxyClient proxy2 = new ProxyClient("dobrehaslo");
            Console.WriteLine(proxy2.GetData());
        }
    }
}