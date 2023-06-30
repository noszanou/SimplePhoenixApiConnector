using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.PhoenixEntitys
{
    public class NpcMonster
    {
        public NpcMonster(string name, int id, byte x, byte y, int vnum, byte hpPercent, byte mpPercent)
        {
            Name = name;
            Id = id;
            X = x;
            Y = y;
            HpPercent = hpPercent;
            MpPercent = mpPercent;
            Vnum = vnum;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("x")]
        public byte X { get; set; }

        [JsonPropertyName("y")]
        public byte Y { get; set; }

        [JsonPropertyName("vnum")]
        public int Vnum { get; set; }

        [JsonPropertyName("hp_percent")]
        public byte HpPercent { get; set; }

        [JsonPropertyName("mp_percent")]
        public byte MpPercent { get; set; }
    }
}