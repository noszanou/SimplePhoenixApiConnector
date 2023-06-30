namespace Shared
{
    public interface IBotConfiguration
    {
        public string Name { get; set; }
        public string Port { get; set; }
    }
    public class BotConfiguration : IBotConfiguration
    {
        public BotConfiguration() 
        {
            Name = string.Empty;
            Port = string.Empty;
        }
        public string Name { get; set; }
        public string Port { get; set; }
    }
}