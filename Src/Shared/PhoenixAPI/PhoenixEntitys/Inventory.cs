using Newtonsoft.Json;

namespace Shared.PhoenixAPI.PhoenixEntitys
{
    public class Inventory
    {
        [JsonProperty("equip")]
        public List<Item> Equip { get; set; } = new();

        [JsonProperty("main")]
        public List<Item> Main { get; set; } = new();

        [JsonProperty("etc")]
        public List<Item> Etc { get; set; } = new();

        [JsonProperty("gold")]
        public int Gold { get; set; }
    }
}