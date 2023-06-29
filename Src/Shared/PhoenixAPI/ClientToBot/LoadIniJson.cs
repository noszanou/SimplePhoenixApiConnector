using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class LoadIniJson
    {
        public LoadIniJson(string path)
        {
            Type = (byte)ObjectType.load_settings;
            Path = path;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }

        [JsonPropertyName("path")]
        public string Path { get; }
    }
}