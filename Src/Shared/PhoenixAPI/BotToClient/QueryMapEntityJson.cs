using Shared.PhoenixAPI.Enums;
using Shared.PhoenixAPI.PhoenixEntitys;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.BotToClient
{
    public class QueryMapEntityJson
    {
        public QueryMapEntityJson()
        {
            Type = (byte)ObjectType.query_map_entities;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }

        [JsonPropertyName("players")]
        public List<Player> Players { get; } = new();

        [JsonPropertyName("npcs")]
        public List<NpcMonster> Npcs { get; } = new();

        [JsonPropertyName("monsters")]
        public List<NpcMonster> Monsters { get; } = new();

        [JsonPropertyName("items")]
        public List<Item> Items { get; } = new();
    }
}