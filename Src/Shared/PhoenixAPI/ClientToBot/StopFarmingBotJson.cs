using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class StopFarmingBotJson
    {
        public StopFarmingBotJson()
        {
            Type = (byte)ObjectType.stop_bot;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }
    }
}