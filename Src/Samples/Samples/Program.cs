using Shared;
using SuperSimpleTcp;
using System.Diagnostics;

namespace Samples
{
    public class Program
    {
        private static List<ClientList> ClientList = new List<ClientList>();

        static void Main(string[] args)
        {
            new Program().MainAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            RefreshClientList();
            FirstOutput();
            for (; ;)
            {
                string line = Console.ReadLine().ToLower();
                switch (line)
                {
                    case "all":
                        SendToAllClient();
                        break;

                    case "refresh":
                        RefreshClientList();
                        break;
                    default:
                        DesiredClient(line);
                        break;
                }
            }
        }

        private static void FirstOutput()
        {
            Console.WriteLine("write in the console all/refresh or characterName to wear sp ^_^");
        }

        private static void SendSlToServer(ClientList client)
        {
            SimpleTcpClient Client = new($"127.0.0.1:{client.Port}");
            Client.Connect();
            Client.SendPacketToServer("sl 0");
            Client.Disconnect();
        }

        public static void DesiredClient(string line)
        {
            var client = ClientList.FirstOrDefault(s => s.Name == line);
            if (client == null)
            {
                Console.WriteLine("couldnt find the client, please use refresh !\r\n current available client:");
                foreach(var c in ClientList)
                {
                    Console.WriteLine(c.Name);
                }
                return;
            }
            SendSlToServer(client);
        }

        public static void SendToAllClient()
        {
            foreach (ClientList client in ClientList)
            {
                SendSlToServer(client);
            }
        }

        public static void RefreshClientList()
        {
            ClientList.Clear();
            foreach (var (process, keyValuePair) in from process in Process.GetProcesses()
                                                    from KeyValuePair<nint, string> keyValuePair in ProcessExternal.GetOpenWindowsFromPID(process.Id)
                                                    select (process, keyValuePair))
            {
                if (!keyValuePair.Value.Contains("- phoenix bot", StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }

                var splittedString = keyValuePair.Value.Split(' ');
                var name = splittedString[2];
                var port = splittedString[5].Split(":")[1];
                ClientList.Add(new ClientList(name, port, process.Id));
            }
        }
    }
}