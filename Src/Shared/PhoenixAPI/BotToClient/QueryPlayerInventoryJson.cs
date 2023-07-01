using Shared.PhoenixAPI.Enums;
using Shared.PhoenixAPI.PhoenixEntitys;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.BotToClient
{
    public class QueryPlayerInventoryJson
    {
        public QueryPlayerInventoryJson(Inventory inventory)
        {
            Type = (byte)ObjectType.query_inventory;
            Inventory = inventory;
        }

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("player_info")]
        public Inventory Inventory { get; } = new();
    }
}