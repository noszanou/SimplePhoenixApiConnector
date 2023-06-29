using Shared.Entitys;
using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class MoveToCordinateJson
    {
        public MoveToCordinateJson(Position position)
        {
            Type = (byte)ObjectType.player_walk;
            PositionX = position.PositionX; 
            PositionY = position.PositionY;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }

        [JsonPropertyName("x")]
        public byte PositionX { get; }

        [JsonPropertyName("y")]
        public byte PositionY { get; }
    }
}
