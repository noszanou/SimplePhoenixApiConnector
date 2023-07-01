using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class GetPlayerSkillJson
    {
        public GetPlayerSkillJson()
        {
            Type = (byte)ObjectType.query_skills_info;
        }

        [JsonProperty("type")]
        public byte Type { get; }
    }
}