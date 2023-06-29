using Shared.PhoenixAPI.Enums;
using System.Text.Json.Serialization;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class SendPacketJson
    {
        public SendPacketJson(string packet) 
        {
            Type = (byte)ObjectType.packet_send;
            Packet = packet;
        }

        [JsonPropertyName("type")]
        public byte Type { get; }

        [JsonPropertyName("packet")]
        public string Packet { get; }
    }
}