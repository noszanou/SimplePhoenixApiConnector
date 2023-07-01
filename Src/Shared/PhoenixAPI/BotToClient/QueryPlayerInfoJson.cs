using Shared.PhoenixAPI.Enums;
using Shared.PhoenixAPI.PhoenixEntitys;
using Newtonsoft.Json;

namespace Shared.PhoenixAPI.BotToClient
{
    public class QueryPlayerInfoJson
    {
        public QueryPlayerInfoJson(Player player)
        {
            Type = (byte)ObjectType.query_player_info;
            Player = player;
        }

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("player_info")]
        public Player Player { get; }
    }
}