namespace Samples
{
    public class ClientList
    {
        public ClientList(string name, string port, int pid) 
        {
            Name = name;
            Port = port;
            PID = pid;
        }
        public string Name { get; set; }
        public string Port { get; set; }
        public int PID { get; set; }
    }
}