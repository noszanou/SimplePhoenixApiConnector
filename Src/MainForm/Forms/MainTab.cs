using Bot;
using Newtonsoft.Json;
using Shared;
using Shared.PhoenixAPI.Enums;
using Shared.PhoenixAPI.ClientToBot;
using System.Diagnostics;
using System.Text;

namespace MainForm
{
    public partial class MainTab : Form
    {
        public MainTab()
        {
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
            new BotForm(comboBox[0], comboBox[1]).ShowDialog();
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
