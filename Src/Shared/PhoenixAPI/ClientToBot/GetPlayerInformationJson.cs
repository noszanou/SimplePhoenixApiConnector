using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class GetPlayerInformationJson
    {
        public GetPlayerInformationJson()
        {
            Type = (byte)ObjectType.query_player_info;
        }

        [JsonProperty("type")]
        public byte Type { get; }
    }
}