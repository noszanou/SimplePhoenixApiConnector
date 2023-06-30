using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.PhoenixEntitys
{
    public class Inventory
    {
        [JsonPropertyName("equip")]
        public List<Item> Equip { get; set; } = new();

        [JsonPropertyName("main")]
        public List<Item> Main { get; set; } = new();

        [JsonPropertyName("etc")]
        public List<Item> Etc { get; set; } = new();
    }
}