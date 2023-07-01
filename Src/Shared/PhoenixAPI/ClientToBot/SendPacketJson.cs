using Newtonsoft.Json;
using Shared.PhoenixAPI.Enums;

namespace Shared.PhoenixAPI.ClientToBot
{
    public class SendPacketJson
    {
        public SendPacketJson(string packet) 
        {
            Type = (byte)ObjectType.packet_send;
            Packet = packet;
        }

        [JsonProperty("type")]
        public byte Type { get; }

        [JsonProperty("packet")]
        public string Packet { get; }
    }
}