using Shared.PhoenixAPI.Enums;
using Shared.PhoenixAPI.PhoenixEntitys;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.BotToClient
{
    public class QueryPlayerInfoJson
    {
        public QueryPlayerInfoJson(Player player)
        {
            Type = (byte)ObjectType.query_player_info;
            Player = player;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }

        [JsonPropertyName("player_info")]
        public Player Player { get; }
    }
}