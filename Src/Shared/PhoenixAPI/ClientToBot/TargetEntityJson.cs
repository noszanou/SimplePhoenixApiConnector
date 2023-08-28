using Newtonsoft.Json;
using Shared.PhoenixAPI.Enums;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class TargetEntityJson
    {
        public TargetEntityJson(EntityType entityType, int entityId)
        {
            Type = (byte)ObjectType.target_entity;
            EntityType = (byte)entityType;
            EntityId = entityId;
        }

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("entity_type")]
        public byte EntityType { get; }

        [JsonProperty("entity_id")]
        public int EntityId { get; }
    }
}
