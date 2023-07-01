using Shared.PhoenixAPI.Enums;
using Shared.PhoenixAPI.PhoenixEntitys;
using Newtonsoft.Json;

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

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("x")]
        public byte PositionX { get; }

        [JsonProperty("y")]
        public byte PositionY { get; }
    }
}
