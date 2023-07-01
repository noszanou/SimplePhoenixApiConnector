using Newtonsoft.Json;
using Shared.PhoenixAPI.Enums;
using Shared.PhoenixAPI.ClientToBot;
using SuperSimpleTcp;
using System.Text;
using Shared;
using Shared.PhoenixAPI.BotToClient;
using Shared.DatEntity.Manager;
using Shared.Bazaar;

namespace Bot
{
    public partial class BotForm : Form
    {
        private readonly IBotConfiguration _botConfiguration;
        private readonly IItemManager _itemManager;
        public BotForm(IBotConfiguration botConfiguration, IItemManager itemManager)
        {
            _botConfiguration = botConfiguration;
            _itemManager = itemManager;
            InitializeComponent();
        }

        private void BotForm_Load(object sender, EventArgs e)
        {
            // Rename title to Bot client name :issou:
            Text = _botConfiguration.Name;

            Client = new SimpleTcpClient($"127.0.0.1:{_botConfiguration.Port}");
            // set events
            Client.Events.Connected += Events_Connected;
            Client.Events.Disconnected += Events_Disconnected;
            Client.Events.DataReceived += Events_DataReceived;
            // let's go!
            Client.Connect();

            Client.SendToTcpClient(new GetPlayerInventoryJson());
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            // Do interaction with Api             
            var stringObject = Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count);

            foreach (var splitedMessage in stringObject.Split("\u0001")) 
            {
                var jsonAsDynamic = JsonConvert.DeserializeObject<dynamic>(splitedMessage);

                if (jsonAsDynamic?.type == null)
                {
                    return;
                }

                switch ((ObjectType)jsonAsDynamic.type)
                {
                    case ObjectType.packet_send:
                        {
                            var json = JsonConvert.DeserializeObject<SendPacketJson>(splitedMessage);
                            AppendToTextBox($"Packet send: {json.Packet}");
                        }
                        break;

                    case ObjectType.packet_recv:
                        {
                            var json = JsonConvert.DeserializeObject<RecvPacketJson>(splitedMessage);
                            AppendToTextBox($"Packet recv: {json.Packet}");

                            if (json.Packet.StartsWith("e_info"))
                            {
                                _botConfiguration.LatestEinfoReceived = json;
                            }
                        }
                        break;

                    case ObjectType.query_player_info:
                        {
                            var json = JsonConvert.DeserializeObject<QueryPlayerInfoJson>(splitedMessage);
                            _botConfiguration.Player = json.Player;
                        }
                        break;

                    case ObjectType.query_inventory:
                        {
                            var json = JsonConvert.DeserializeObject<QueryPlayerInventoryJson>(splitedMessage);
                            _botConfiguration.Inventory = json.Inventory;

                            // Pet bead
                            var bead = _botConfiguration.Inventory.Equip.FirstOrDefault(s => s.Vnum == 192);
                            if (bead == null)
                            {
                                continue;
                            }
                            var item = _itemManager.Items[bead.Vnum];
                            var bazaarInfo = bead.GetBazaarInfoItem(Client, _botConfiguration, _itemManager);
                            AppendToTextBox($"name: {item.Name} price: {item.Price}");
                            AppendToTextBox($"Bazaar category: {bazaarInfo.category} subcategory: {bazaarInfo.subCategory}");
                        }
                        break;

                    case ObjectType.query_skills_info:
                        {
                            var json = JsonConvert.DeserializeObject<QueryPlayerSkillJson>(splitedMessage);
                            _botConfiguration.Skills.AddRange(json.Skills);
                        }
                        break;

                    case ObjectType.query_map_entities:
                        {
                            var json = JsonConvert.DeserializeObject<QueryMapEntityJson>(splitedMessage);
                        }
                        break;

                }
                // Json parse nieunieu
            }

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
            Invoke(new MethodInvoker(delegate ()
            {
                textBox1.Text += $"{DateTime.Now.ToString(@"hh\:mm\:ss")} | {text} {Environment.NewLine}";
            }));
            //textBox1.AppendText(DateTime.Now.ToString(@"hh\:mm\:ss") + " | " + text + Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client.SendToTcpClient(new RecvPacketJson($"gold {int.MaxValue} 10000"));
            Client.SendToTcpClient(new RecvPacketJson($"info Ayo!"));
        }

        public static SimpleTcpClient Client { get; set; }
    }
}