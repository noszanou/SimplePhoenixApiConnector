using Shared.PhoenixAPI.ClientToBot;
using Shared.PhoenixAPI.PhoenixEntitys;

namespace Shared
{
    public interface IBotConfiguration
    {
        public string Name { get; set; }
        public string Port { get; set; }
        public RecvPacketJson? LatestEinfoReceived { get; set; }
        public Inventory? Inventory { get; set; }
        public Player? Player { get; set; }
        public List<Skill> Skills { get; set; }
    }
    public class BotConfiguration : IBotConfiguration
    {
        public BotConfiguration() 
        {
            Name = string.Empty;
            Port = string.Empty;
            Skills = new List<Skill>();
        }
        public string Name { get; set; }
        public string Port { get; set; }

        public RecvPacketJson? LatestEinfoReceived { get; set; }
        public Inventory? Inventory { get; set; }
        public Player? Player { get; set; }
        public List<Skill> Skills { get; set; }
    }
}