using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class WalkAndCollectNpcJson
    {
        public WalkAndCollectNpcJson(int npcId)
        {
            Type = (byte)ObjectType.collect;
            NpcId = npcId;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }

        [JsonPropertyName("npc_id")]
        public int NpcId { get; }
    }
}