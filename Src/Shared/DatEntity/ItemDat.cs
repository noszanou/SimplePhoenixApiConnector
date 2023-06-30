using Shared.DatEntity.Enums.Items;
using Shared.DatEntity.Enums.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DatEntity
{
    public class ItemDat
    {
        public int Id { get; set; }
        public byte BasicUpgrade { get; set; }
        public byte CellonLvl { get; set; }
        public byte Class { get; set; }
        public short CloseDefence { get; set; }
        public byte Color { get; set; }
        public short Concentrate { get; set; }
        public sbyte CriticalLuckRate { get; set; }
        public short CriticalRate { get; set; }
        public short DamageMaximum { get; set; }
        public short DamageMinimum { get; set; }
        public byte DarkElement { get; set; }
        public short DarkResistance { get; set; }
        public short DefenceDodge { get; set; }
        public short DistanceDefence { get; set; }
        public short DistanceDefenceDodge { get; set; }
        public short Effect { get; set; }
        public int EffectValue { get; set; }
        public byte Element { get; set; }
        public short ElementRate { get; set; }
        public EquipmentType EquipmentSlot { get; set; }
        public byte FireElement { get; set; }
        public short FireResistance { get; set; }
        public byte Height { get; set; }
        public short HitRate { get; set; }
        public short Hp { get; set; }
        public short HpRegeneration { get; set; }
        public bool IsMinilandActionable { get; set; }
        public bool IsColorable { get; set; }
        public bool IsTimeSpaceRewardBox { get; set; }
        public bool ShowDescriptionOnHover { get; set; }
        public bool Flag3 { get; set; }
        public bool FollowMouseOnUse { get; set; }
        public bool ShowSomethingOnHover { get; set; }
        public bool PlaySoundOnPickup { get; set; }
        public bool Flag7 { get; set; }
        public bool IsLimited { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsDroppable { get; set; }
        public bool IsHeroic { get; set; }
        public bool ShowWarningOnUse { get; set; }
        public bool IsWarehouse { get; set; }
        public bool IsSoldable { get; set; }
        public bool IsTradable { get; set; }
        public byte ItemSubType { get; set; }
        public ItemType ItemType { get; set; }
        public long ItemValidTime { get; set; }
        public byte LevelJobMinimum { get; set; }
        public byte LevelMinimum { get; set; }
        public byte LightElement { get; set; }
        public short LightResistance { get; set; }
        public short MagicDefence { get; set; }
        public byte MaxCellon { get; set; }
        public byte MaxCellonLvl { get; set; }
        public short MaxElementRate { get; set; }
        public byte MaximumAmmo { get; set; }
        public int MinilandObjectPoint { get; set; }
        public short MoreHp { get; set; }
        public short MoreMp { get; set; }
        public short Morph { get; set; }
        public short Mp { get; set; }
        public short MpRegeneration { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte DescriptionLineCount { get; set; }
        public long Price { get; set; }
        public byte ReputationMinimum { get; set; }
        public long ReputPrice { get; set; }
        public byte Sex { get; set; }
        public byte Speed { get; set; }
        public byte SpPointsUsage { get; set; }
        public InventoryType Type { get; set; }
        public short WaitDelay { get; set; }
        public byte WaterElement { get; set; }
        public short WaterResistance { get; set; }
        public byte Width { get; set; }
        public AttackType AttackType { get; set; }
        public bool UseReputationAsPrice { get; set; }
        public byte PartnerClass { get; set; }
        public bool IsPartnerSpecialist { get; set; }
        public byte SpMorphId { get; set; }
        public short ItemLeftType { get; set; }
        public int LeftUsages { get; set; }
        public int IconId { get; set; }
        public short ShellMinimumLevel { get; set; }
        public short ShellMaximumLevel { get; set; }
        public ShellType ShellType { get; set; }
        public int[] Data { get; set; }
        public List<BCardObject> BCards { get; set; } = new();
        public Dictionary<RegionLanguageType, string> LangName { get; set; } = new();
        public Dictionary<RegionLanguageType, string> LangDescription { get; set; } = new();
    }
}
