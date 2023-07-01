using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class WalkAndCollectNpcJson
    {
        public WalkAndCollectNpcJson(int npcId)
        {
            Type = (byte)ObjectType.collect;
            NpcId = npcId;
        }

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("npc_id")]
        public int NpcId { get; }
    }
}