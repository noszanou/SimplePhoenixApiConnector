using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class AttackMonsterWithPartnerSkillJson
    {
        public AttackMonsterWithPartnerSkillJson(int monsterId, int skillId)
        {
            Type = (byte)ObjectType.partner_skill;
            MonsterId = monsterId;
            SkillId = skillId;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }

        [JsonPropertyName("monster_id")]
        public int MonsterId { get; }

        [JsonPropertyName("skill_id")]
        public int SkillId { get; }
    }
}