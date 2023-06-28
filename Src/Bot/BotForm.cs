using SuperSimpleTcp;

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


        public static SimpleTcpClient? Client { get; set; }
    }
}