using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class LoadIniJson
    {
        public LoadIniJson(string path)
        {
            Type = (byte)ObjectType.load_settings;
            Path = path;
        }

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("path")]
        public string Path { get; }
    }
}