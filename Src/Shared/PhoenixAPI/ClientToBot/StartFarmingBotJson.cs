using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class StartFarmingBotJson
    {
        public StartFarmingBotJson()
        {
            Type = (byte)ObjectType.start_bot;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }
    }
}