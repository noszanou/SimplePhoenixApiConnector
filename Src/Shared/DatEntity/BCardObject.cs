using Shared.DatEntity.Enums.Bcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DatEntity
{
    public class BCardObject
    {
        public byte SubType { get; set; }

        public short Type { get; set; }

        public int FirstData { get; set; }

        public int SecondData { get; set; }

        public int ProcChance { get; set; }

        public byte? TickPeriod { get; set; }

        public byte CastType { get; set; }

        public BCardScalingType FirstDataScalingType { get; set; }

        public BCardScalingType SecondDataScalingType { get; set; }

        public bool? IsSecondBCardExecution { get; set; }

        public int? CardId { get; set; }

        public int? ItemVNum { get; set; }

        public int? SkillVNum { get; set; }

        public int? NpcMonsterVNum { get; set; }

        public BCardNpcMonsterTriggerType? TriggerType { get; set; }

        public BCardNpcTriggerType? NpcTriggerType { get; set; }

        public bool IsMonsterMode { get; set; }
    }
}
