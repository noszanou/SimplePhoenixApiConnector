using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class StopMiniGameBotJson
    {
        public StopMiniGameBotJson()
        {
            Type = (byte)ObjectType.stop_minigame_bot;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }
    }
}