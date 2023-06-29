using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class AttackMonsterJson
    {
        public AttackMonsterJson(int monsterId)
        {
            Type = (byte)ObjectType.attack;
            MonsterId = monsterId;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }

        [JsonPropertyName("monster_id")]
        public int MonsterId { get; }
    }
}