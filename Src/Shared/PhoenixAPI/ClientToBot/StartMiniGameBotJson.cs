using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class StartMiniGameBotJson
    {
        public StartMiniGameBotJson()
        {
            Type = (byte)ObjectType.start_minigame_bot;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }
    }
}