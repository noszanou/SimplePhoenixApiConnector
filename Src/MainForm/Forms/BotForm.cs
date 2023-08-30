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

            Client.RequestPlayerInventoryToAPI();
            Client.RequestPlayerInformationToAPI();
            Client.RequestPlayerSkillToAPI();
            _botConfiguration.LatestEinfoReceived = null;
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            // Do interaction with Api
            var stringObject = Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count);

            foreach (var splitedMessage in stringObject.Split("\u0001")) 
            {
                Console.WriteLine(splitedMessage.ToString());

                var defaultJson = JsonConvert.DeserializeObject<DefaultJson>(splitedMessage);

                if (defaultJson == null)
                {
                    continue;
                }

                switch ((ObjectType)defaultJson.Type)
                {
                    case ObjectType.packet_send:
                        {
                            HandlePacketSend(JsonConvert.DeserializeObject<SendPacketJson>(splitedMessage));
                        }
                        break;

                    case ObjectType.packet_recv:
                        {
                            HandlePacketReceived(JsonConvert.DeserializeObject<RecvPacketJson>(splitedMessage));
                        }
                        break;

                    case ObjectType.query_player_info:
                        {
                            HandleQueryPlayer(JsonConvert.DeserializeObject<QueryPlayerInfoJson>(splitedMessage));
                        }
                        break;

                    case ObjectType.query_inventory:
                        {
                            HandleQueryInventory(JsonConvert.DeserializeObject<QueryPlayerInventoryJson>(splitedMessage));
                        }
                        break;

                    case ObjectType.query_skills_info:
                        {
                            HandleQuerySkill(JsonConvert.DeserializeObject<QueryPlayerSkillJson>(splitedMessage));
                        }
                        break;

                    case ObjectType.query_map_entities:
                        {
                            HandleQueryMapEntity(JsonConvert.DeserializeObject<QueryMapEntityJson>(splitedMessage));
                        }
                        break;
                }
            }

        }

        private void HandleQueryMapEntity(QueryMapEntityJson? json)
        {
            if (json == null)
            {
                return;
            }
        }

        private void HandleQuerySkill(QueryPlayerSkillJson? json)
        {
            if (json == null)
            {
                return;
            }
            _botConfiguration.Skills = json.Skills;
        }
        private void HandleQueryInventory(QueryPlayerInventoryJson? json)
        {
            if (json == null)
            {
                return;
            }

            _botConfiguration.Inventory = json.Inventory;

            // exemple c_reg parsing packet
            // Pet bead
            var bead = _botConfiguration.Inventory.Equip.FirstOrDefault(s => s.Vnum == 192);
            if (bead == null)
            {
                return;
            }
            if (!bead.Vnum.HasValue) return;

            var item = _itemManager.Items[bead.Vnum.Value];
            var bazaarInfo = bead.GetBazaarInfoItem(Client, _botConfiguration, _itemManager);
            AppendToTextBox($"name: {item.Name} price: {item.Price}");
            AppendToTextBox($"Bazaar category: {bazaarInfo.category} subcategory: {bazaarInfo.subCategory}");
        }

        private void HandleQueryPlayer(QueryPlayerInfoJson? json)
        {
            if (json == null)
            {
                return;
            }
            _botConfiguration.Player = json.Player;
        }

        private void HandlePacketSend(SendPacketJson? json)
        {
            if (json == null)
            {
                return;
            }
            AppendToTextBox($"Packet send: {json.Packet}");
        }

        private void HandlePacketReceived(RecvPacketJson? json)
        {
            if (json == null)
            {
                return;
            }
            AppendToTextBox($"Packet recv: {json.Packet}");

            string[] splittedPacket = json.Packet.Split(" ");

            switch (splittedPacket[0]) // header
            {
                case "e_info":
                    _botConfiguration.LatestEinfoReceived = json;
                    break;
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
            Client.SendPacketToClient($"gold {int.MaxValue} 10000");
            Client.SendPacketToClient("info Ayo!");
        }

        public static SimpleTcpClient Client { get; set; }
    }
}