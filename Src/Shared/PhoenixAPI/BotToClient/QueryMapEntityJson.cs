using Shared.PhoenixAPI.Enums;
using Shared.PhoenixAPI.PhoenixEntitys;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.BotToClient
{
    public class QueryMapEntityJson
    {
        public QueryMapEntityJson()
        {
            Type = (byte)ObjectType.query_map_entities;
        }

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("players")]
        public List<Player> Players { get; } = new();

        [JsonProperty("npcs")]
        public List<NpcMonster> Npcs { get; } = new();

        [JsonProperty("monsters")]
        public List<NpcMonster> Monsters { get; } = new();

        [JsonProperty("items")]
        public List<Item> Items { get; } = new();
    }
}