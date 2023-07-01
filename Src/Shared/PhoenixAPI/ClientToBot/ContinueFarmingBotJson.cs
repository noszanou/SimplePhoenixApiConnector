using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class ContinueFarmingBotJson
    {
        public ContinueFarmingBotJson()
        {
            Type = (byte)ObjectType.continue_bot;
        }

        [JsonProperty("type")]
        public byte Type { get; }
    }
}