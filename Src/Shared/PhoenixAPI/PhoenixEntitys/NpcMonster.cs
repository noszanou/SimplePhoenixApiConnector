using Newtonsoft.Json;

namespace Shared.PhoenixAPI.PhoenixEntitys
{
    public class NpcMonster
    {
        public NpcMonster(string name, int id, byte x, byte y, short? vnum, byte hpPercent, byte mpPercent)
        {
            Name = name;
            Id = id;
            X = x;
            Y = y;
            HpPercent = hpPercent;
            MpPercent = mpPercent;
            Vnum = vnum;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("x")]
        public byte X { get; set; }

        [JsonProperty("y")]
        public byte Y { get; set; }

        [JsonProperty("vnum", NullValueHandling = NullValueHandling.Ignore)]
        public short? Vnum { get; set; }

        [JsonProperty("hp_percent")]
        public byte HpPercent { get; set; }

        [JsonProperty("mp_percent")]
        public byte MpPercent { get; set; }
    }
}