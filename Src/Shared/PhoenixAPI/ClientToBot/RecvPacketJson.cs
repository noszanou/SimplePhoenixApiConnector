using Newtonsoft.Json;
using Shared.PhoenixAPI.Enums;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class RecvPacketJson
    {
        public RecvPacketJson(string packet)
        {
            Type = (byte)ObjectType.packet_recv;
            Packet = packet;
        }

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("packet")]
        public string Packet { get; }
    }
}