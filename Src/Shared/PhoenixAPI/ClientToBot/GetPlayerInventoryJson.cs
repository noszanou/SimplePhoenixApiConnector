using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class GetPlayerInventoryJson
    {
        public GetPlayerInventoryJson()
        {
            Type = (byte)ObjectType.query_inventory;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }
    }
}