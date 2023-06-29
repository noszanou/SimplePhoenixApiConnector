using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Shared.Entitys
{
    public class Player
    {
        public Player(string name, int id, byte positionX, byte positionY, byte level, byte heroLevel, byte hpPercent, byte mpPercent, int? mapId, bool? isResting, string? family)
        {
            Name = name;
            Id = id;
            PositionX = positionX;
            PositionY = positionY;
            Level = level;
            HeroLevel = heroLevel;
            HpPercent = hpPercent;
            MpPercent = mpPercent;
            MapId = mapId;
            IsResting = isResting;
            Family = family;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("x")]
        public byte PositionX { get; set; }

        [JsonPropertyName("y")]
        public byte PositionY { get; set; }

        [JsonPropertyName("level")]
        public byte Level { get; set; }

        [JsonPropertyName("champion_level")]
        public byte HeroLevel { get; set; }

        [JsonPropertyName("hp_percent")]
        public byte HpPercent { get; set; }

        [JsonPropertyName("mp_percent")]
        public byte MpPercent { get; set; }

        [JsonProperty("map_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? MapId { get; set; }

        [JsonProperty("is_resting", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsResting { get; set; }

        [JsonProperty("family", NullValueHandling = NullValueHandling.Ignore)]
        public string? Family { get; set; }
    }
}
