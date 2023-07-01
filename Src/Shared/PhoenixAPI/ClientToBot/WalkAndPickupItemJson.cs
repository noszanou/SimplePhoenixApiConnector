using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class WalkAndPickupItemJson
    {
        public WalkAndPickupItemJson(int itemId)
        {
            Type = (byte)ObjectType.pick_up;
            ItemId = itemId;
        }

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("item_id")]
        public int ItemId { get; }
    }
}