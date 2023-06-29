using Shared.Entitys;
using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.BotToClient
{
    public class QueryPlayerInventoryJson
    {
        public QueryPlayerInventoryJson(Inventory inventory)
        {
            Type = (byte)ObjectType.query_inventory;
            Inventory = inventory;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }

        [JsonPropertyName("player_info")]
        public Inventory Inventory { get; } = new();
    }
}