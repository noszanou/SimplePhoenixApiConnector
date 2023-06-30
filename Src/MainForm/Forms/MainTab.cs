using Bot;
using Shared;
using System.Diagnostics;

namespace MainForm
{
    public partial class MainTab : Form
    {
        private readonly BotForm _botForm;
        private readonly IBotConfiguration _botConfiguration;
        public MainTab(BotForm botForm, IBotConfiguration botConfiguration)
        {
            _botForm = botForm;
            _botConfiguration = botConfiguration; 
            InitializeComponent();
        }

        public delegate bool CallbackDef(int hWnd, int lParam);

        public void RefreshClientList()
        {
            comboBox1.Items.Clear();
            foreach (var process in Process.GetProcesses())
            {
                foreach (var keyValuePair in ProcessExternal.GetOpenWindowsFromPID(process.Id))
                {
                    if (!keyValuePair.Value.ToLower().Contains("- phoenix bot"))
                    {
                        continue;
                    }
                    var splittedString = keyValuePair.Value.Split(' ');
                    var name = splittedString[2];
                    var port = splittedString[5].Split(":")[1];

                    comboBox1.Items.Add($"{name}:{port}");
                }
            }

            if (comboBox1.Items.Count <= 0)
            {
                return;
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) 
            { 
               return; 
            }
            var comboBox = ((string)comboBox1.Items[comboBox1.SelectedIndex]).Split(':');
            _botConfiguration.Port = comboBox[1];
            _botConfiguration.Name = comboBox[0];
            _botForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshClientList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshClientList();
        }
    }
}
