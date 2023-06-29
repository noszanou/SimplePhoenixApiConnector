using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class WalkAndPickupItemJson
    {
        public WalkAndPickupItemJson(int itemId)
        {
            Type = (byte)ObjectType.pick_up;
            ItemId = itemId;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }

        [JsonPropertyName("item_id")]
        public int ItemId { get; }
    }
}