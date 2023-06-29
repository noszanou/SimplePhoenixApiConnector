using Shared.Entitys;
using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.BotToClient
{
    public class QueryPlayerSkillJson
    {
        public QueryPlayerSkillJson(List<Skill> skills)
        {
            Type = (byte)ObjectType.query_skills_info;
            Skills = skills;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }

        [JsonPropertyName("player_info")]
        public List<Skill> Skills { get; } = new();
    }
}