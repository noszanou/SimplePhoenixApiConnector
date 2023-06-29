using Newtonsoft.Json;
using Shared.PhoenixAPI.Enums;
using Shared.PhoenixAPI.ClientToBot;
using SuperSimpleTcp;
using System.Text;
using Shared;
using Shared.PhoenixAPI.BotToClient;

namespace Bot
{
    public partial class BotForm : Form
    {
        public BotForm(string name, string port)
        {
            InitializeComponent();
            _name = name;
            _port = port;
        }

        private readonly string _name;
        private readonly string _port;

        private void BotForm_Load(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Rename title to Bot client name :issou:
            Text = _name;

            Client = new SimpleTcpClient($"127.0.0.1:{_port}");
            // set events
            Client.Events.Connected += Events_Connected;
            Client.Events.Disconnected += Events_Disconnected;
            Client.Events.DataReceived += Events_DataReceived;
            // let's go!
            Client.Connect();
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            // Do interaction with Api             
            var stringObject = Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count);

            var jsonAsDynamic = JsonConvert.DeserializeObject<dynamic>(stringObject);

            if (jsonAsDynamic?.type == null)
            {
                return;
            }

            switch ((ObjectType)jsonAsDynamic.type)
            {
                case ObjectType.packet_send:
                    {
                        var json = JsonConvert.DeserializeObject<SendPacketJson>(stringObject);
                        AppendToTextBox($"Packet send: {json.Packet}");
                    }
                    break;

                case ObjectType.packet_recv:
                    {
                        var json = JsonConvert.DeserializeObject<RecvPacketJson>(stringObject);
                        AppendToTextBox($"Packet recv: {json.Packet}");
                    }
                    break;

                case ObjectType.query_player_info:
                    {
                        var json = JsonConvert.DeserializeObject<QueryPlayerInfoJson>(stringObject);
                    }
                    break;

                case ObjectType.query_inventory:
                    {
                        var json = JsonConvert.DeserializeObject<QueryPlayerInventoryJson>(stringObject);
                    }
                    break;

                case ObjectType.query_skills_info:
                    {
                        var json = JsonConvert.DeserializeObject<QueryPlayerSkillJson>(stringObject);
                    }
                    break;

                case ObjectType.query_map_entities:
                    {
                        var json = JsonConvert.DeserializeObject<QueryMapEntityJson>(stringObject);
                    }
                    break;

            }
            // Json parse nieunieu
        }

        private void Events_Disconnected(object? sender, ConnectionEventArgs e)
        {
            AppendToTextBox("Disconnected from api");
        }

        private void Events_Connected(object? sender, ConnectionEventArgs e)
        {
            AppendToTextBox("Connected to api");
        }

        public void AppendToTextBox(string text)
        {
            textBox1.AppendText(DateTime.Now.ToString(@"hh\:mm\:ss") + " | " + text + Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client.SendToTcpClient(new RecvPacketJson($"gold {int.MaxValue} 10000"));
            Client.SendToTcpClient(new RecvPacketJson($"info Ayo!"));
        }

        public static SimpleTcpClient Client { get; set; }
    }
}