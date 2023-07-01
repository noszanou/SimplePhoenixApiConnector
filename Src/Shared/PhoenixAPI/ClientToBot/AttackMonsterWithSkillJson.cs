using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class AttackMonsterWithSkillJson
    {
        public AttackMonsterWithSkillJson(int monsterId,int skillId)
        {
            Type = (byte)ObjectType.player_skill;
            MonsterId = monsterId;
            SkillId = skillId;
        }

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("monster_id")]
        public int MonsterId { get; }

        [JsonProperty("skill_id")]
        public int SkillId { get; }
    }
}
