using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class StopFarmingBotJson
    {
        public StopFarmingBotJson()
        {
            Type = (byte)ObjectType.stop_bot;
        }

        [JsonProperty("type")]
        public byte Type { get; }
    }
}