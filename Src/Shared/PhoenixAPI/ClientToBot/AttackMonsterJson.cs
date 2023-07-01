using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class AttackMonsterJson
    {
        public AttackMonsterJson(int monsterId)
        {
            Type = (byte)ObjectType.attack;
            MonsterId = monsterId;
        }

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("monster_id")]
        public int MonsterId { get; }
    }
}