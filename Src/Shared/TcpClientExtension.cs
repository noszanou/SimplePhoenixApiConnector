using Newtonsoft.Json;
using SuperSimpleTcp;
using System.Text;

namespace Shared
{
    public static class TcpClientExtension
    {
        public static void SendToTcpClient(this SimpleTcpClient client, object e)
        {
            client.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(e, Formatting.Indented) + 0x01));
        }
    }
}