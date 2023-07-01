using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class StopMiniGameBotJson
    {
        public StopMiniGameBotJson()
        {
            Type = (byte)ObjectType.stop_minigame_bot;
        }

        [JsonProperty("type")]
        public byte Type { get; }
    }
}