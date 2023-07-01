using Shared.PhoenixAPI.Enums;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class GetMapEntityJson
    {
        public GetMapEntityJson()
        {
            Type = (byte)ObjectType.query_map_entities;
        }

        [JsonProperty("type")]
        public byte Type { get; }
    }
}