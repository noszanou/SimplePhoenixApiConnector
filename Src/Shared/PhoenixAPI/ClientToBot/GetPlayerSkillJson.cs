using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class GetPlayerSkillJson
    {
        public GetPlayerSkillJson()
        {
            Type = (byte)ObjectType.query_skills_info;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }
    }
}