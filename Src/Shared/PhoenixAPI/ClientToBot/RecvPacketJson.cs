using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class RecvPacketJson
    {
        public RecvPacketJson(string packet)
        {
            Type = (byte)ObjectType.packet_recv;
            Packet = packet;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }

        [JsonPropertyName("packet")]
        public string Packet { get; }
    }
}