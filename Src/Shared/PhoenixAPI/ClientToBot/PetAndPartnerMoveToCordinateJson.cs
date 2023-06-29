using Shared.Entitys;
using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class PetAndPartnerMoveToCordinateJson
    {
        public PetAndPartnerMoveToCordinateJson(Position position)
        {
            Type = (byte)ObjectType.pets_walk;
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
