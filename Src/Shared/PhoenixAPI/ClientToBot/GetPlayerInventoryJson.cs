using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class GetPlayerInventoryJson
    {
        public GetPlayerInventoryJson()
        {
            Type = (byte)ObjectType.query_inventory;
        }

        [JsonProperty("type")]
        public byte Type { get; }
    }
}