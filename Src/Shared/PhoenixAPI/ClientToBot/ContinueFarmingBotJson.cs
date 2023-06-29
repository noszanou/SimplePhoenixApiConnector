using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class ContinueFarmingBotJson
    {
        public ContinueFarmingBotJson()
        {
            Type = (byte)ObjectType.continue_bot;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }
    }
}