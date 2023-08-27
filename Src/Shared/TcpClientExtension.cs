using Newtonsoft.Json;
using SuperSimpleTcp;
using System.Text;

namespace Shared
{
    public static class TcpClientExtension
    {
        public static void SendToTcpClient(this SimpleTcpClient client, object e)
        {
            var jsonParsed = JsonConvert.SerializeObject(e, Formatting.Indented);
            client.Send(Encoding.UTF8.GetBytes(jsonParsed + "\u0001"));
        }
    }
}