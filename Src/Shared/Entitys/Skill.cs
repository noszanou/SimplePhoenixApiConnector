using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Shared.Entitys
{
    public class Skill
    {
        public Skill(string name, int vnum, int id, short? range, short area, short manaCost, bool isReady) 
        { 
            Name = name;
            Vnum = vnum;
            Id = id;
            Area = area;
            ManaCost = manaCost;
            IsReady = isReady;
            Range = range;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("vnum")]
        public int Vnum { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("range", NullValueHandling = NullValueHandling.Ignore)]
        public short? Range { get; set; }

        [JsonPropertyName("area")]
        public short Area { get; set; }

        [JsonPropertyName("mana_cost")]
        public short ManaCost { get; set; }

        [JsonPropertyName("is_ready")]
        public bool IsReady { get; set; }
    }
}