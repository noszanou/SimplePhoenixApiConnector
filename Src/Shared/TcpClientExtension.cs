using Newtonsoft.Json;
using Shared.PhoenixAPI.ClientToBot;
using Shared.PhoenixAPI.Enums;
using Shared.PhoenixAPI.PhoenixEntitys;
using SuperSimpleTcp;
using System.Text;

namespace Shared
{
    public static class TcpClientExtension
    {
        public static void SendToTcpClient(this SimpleTcpClient client, object e)
        {
            var jsonParsed = JsonConvert.SerializeObject(e, Formatting.Indented);
            client.Send(Encoding.UTF8.GetBytes(jsonParsed + "\u0001"));
        }

        public static void AttackMonster(this SimpleTcpClient client, int monsterId)
        {
            client.SendToTcpClient(new AttackMonsterJson(monsterId));
        }

        public static void AttackMonsterWithPartnerSkill(this SimpleTcpClient client, int monsterId, int skillId)
        {
            client.SendToTcpClient(new AttackMonsterWithPartnerSkillJson(monsterId, skillId));
        }

        public static void AttackMonsterWithPetSkill(this SimpleTcpClient client, int monsterId, int skillId)
        {
            client.SendToTcpClient(new AttackMonsterWithPetSkillJson(monsterId, skillId));
        }

        public static void AttackMonsterWithSkill(this SimpleTcpClient client, int monsterId, int skillId)
        {
            client.SendToTcpClient(new AttackMonsterWithSkillJson(monsterId, skillId));
        }

        public static void ContinueBot(this SimpleTcpClient client)
        {
            client.SendToTcpClient(new ContinueFarmingBotJson());
        }

        public static void RequestMapEntityToAPI(this SimpleTcpClient client)
        {
            client.SendToTcpClient(new GetMapEntityJson());
        }

        public static void RequestPlayerInformationToAPI(this SimpleTcpClient client)
        {
            client.SendToTcpClient(new GetPlayerInformationJson());
        }

        public static void RequestPlayerInventoryToAPI(this SimpleTcpClient client)
        {
            client.SendToTcpClient(new GetPlayerInventoryJson());
        }

        public static void RequestPlayerSkillToAPI(this SimpleTcpClient client)
        {
            client.SendToTcpClient(new GetPlayerSkillJson());
        }

        public static void LoadIni(this SimpleTcpClient client, string path)
        {
            client.SendToTcpClient(new LoadIniJson(path));
        }

        public static void MoveToCordinate(this SimpleTcpClient client, Position pos)
        {
            client.SendToTcpClient(new MoveToCordinateJson(pos));
        }

        public static void PetAndPartnerMoveToCordinate(this SimpleTcpClient client, Position pos)
        {
            client.SendToTcpClient(new PetAndPartnerMoveToCordinateJson(pos));
        }

        public static void SendPacketToClient(this SimpleTcpClient client, string packet)
        {
            client.SendToTcpClient(new RecvPacketJson(packet));
        }

        public static void SendPacketToServer(this SimpleTcpClient client, string packet)
        {
            client.SendToTcpClient(new SendPacketJson(packet));
        }

        public static void StartBot(this SimpleTcpClient client)
        {
            client.SendToTcpClient(new StartFarmingBotJson());
        }

        public static void StopBot(this SimpleTcpClient client)
        {
            client.SendToTcpClient(new StopFarmingBotJson());
        }

        public static void StartMiniGameBot(this SimpleTcpClient client)
        {
            client.SendToTcpClient(new StartMiniGameBotJson());
        }

        public static void StopMiniGameBot(this SimpleTcpClient client)
        {
            client.SendToTcpClient(new StopMiniGameBotJson());
        }

        public static void TargetEntity(this SimpleTcpClient client, EntityType entityType, int entityId)
        {
            client.SendToTcpClient(new TargetEntityJson(entityType, entityId));
        }

        public static void WalkAndCollectNpc(this SimpleTcpClient client, int entityId)
        {
            client.SendToTcpClient(new WalkAndCollectNpcJson(entityId));
        }

        public static void WalkAndPickupItem(this SimpleTcpClient client, int entityId)
        {
            client.SendToTcpClient(new WalkAndPickupItemJson(entityId));
        }
    }
}