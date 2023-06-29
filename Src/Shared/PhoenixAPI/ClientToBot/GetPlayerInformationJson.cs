using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class GetPlayerInformationJson
    {
        public GetPlayerInformationJson()
        {
            Type = (byte)ObjectType.query_player_info;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }
    }
}