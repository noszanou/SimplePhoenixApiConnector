using Newtonsoft.Json;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.PhoenixEntitys
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

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("x")]
        public byte PositionX { get; set; }

        [JsonProperty("y")]
        public byte PositionY { get; set; }

        [JsonProperty("level")]
        public byte Level { get; set; }

        [JsonProperty("champion_level")]
        public byte HeroLevel { get; set; }

        [JsonProperty("hp_percent")]
        public byte HpPercent { get; set; }

        [JsonProperty("mp_percent")]
        public byte MpPercent { get; set; }

        [JsonProperty("map_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? MapId { get; set; }

        [JsonProperty("is_resting", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsResting { get; set; }

        [JsonProperty("family", NullValueHandling = NullValueHandling.Ignore)]
        public string? Family { get; set; }
    }
}
