using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class StartMiniGameBotJson
    {
        public StartMiniGameBotJson()
        {
            Type = (byte)ObjectType.start_minigame_bot;
        }

        [JsonProperty("type")]
        public byte Type { get; }
    }
}