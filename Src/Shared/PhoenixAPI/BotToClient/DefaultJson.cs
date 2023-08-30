using Newtonsoft.Json;

namespace Shared.PhoenixAPI.BotToClient
{
    public class DefaultJson
    {
        [JsonProperty("type")]
        public byte Type { get; }
    }
}
