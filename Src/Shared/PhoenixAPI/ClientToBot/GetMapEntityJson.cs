using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class GetMapEntityJson
    {
        public GetMapEntityJson()
        {
            Type = (byte)ObjectType.query_map_entities;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }
    }
}