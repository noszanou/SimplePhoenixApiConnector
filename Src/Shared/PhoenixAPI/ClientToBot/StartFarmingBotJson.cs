using Newtonsoft.Json;
using Shared.PhoenixAPI.Enums;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class StartFarmingBotJson
    {
        public StartFarmingBotJson()
        {
            Type = (byte)ObjectType.start_bot;
        }

        [JsonProperty("type")]
        public byte Type { get; }
    }
}