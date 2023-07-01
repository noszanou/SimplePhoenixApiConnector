using Shared.PhoenixAPI.Enums;
using Shared.PhoenixAPI.PhoenixEntitys;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.BotToClient
{
    public class QueryPlayerSkillJson
    {
        public QueryPlayerSkillJson(List<Skill> skills)
        {
            Type = (byte)ObjectType.query_skills_info;
            Skills = skills;
        }

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("player_info")]
        public List<Skill> Skills { get; } = new();
    }
}