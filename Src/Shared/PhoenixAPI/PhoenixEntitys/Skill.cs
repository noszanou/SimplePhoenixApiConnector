using Newtonsoft.Json;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.PhoenixEntitys
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

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("vnum")]
        public int Vnum { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("range", NullValueHandling = NullValueHandling.Ignore)]
        public short? Range { get; set; }

        [JsonProperty("area")]
        public short Area { get; set; }

        [JsonProperty("mana_cost")]
        public short ManaCost { get; set; }

        [JsonProperty("is_ready")]
        public bool IsReady { get; set; }
    }
}