using Shared.DatEntity.Enums.Bcards;
using Shared.DatEntity.Enums.Items;
using Shared.DatEntity.Parsing;

namespace Shared.DatEntity.Manager
{
    public interface IItemManager
    {
        Dictionary<int, ItemDat> Items { get; set; }
    }
    public class ItemManager : IItemManager
    {
        private const string FileName = "Item.dat";
        public Dictionary<int, ItemDat> Items { get; set; } = new();

        public ItemManager()
        {
            Import();
        }

        public void Import()
        {
            var filePath = Path.Combine(MDRRRR.DatFolder, FileName);
            foreach (var block in new GenericParser("END", filePath, 1).Dictionary)
            {
                var vnum = short.Parse(block["VNUM"][0][2]);

                var item = new ItemDat
                {
                    Id = vnum,
                    Price = long.Parse(block["VNUM"][0][3]),
                    Name = block["NAME"][0][2],
                    AttackType = (AttackType)Convert.ToByte(block["TYPE"][0][2]),
                };

                FillBuff(block["BUFF"][0], item);

                FillMorphAndIndexValues(block["INDEX"][0], item);

                item.Class = item.EquipmentSlot == EquipmentType.Fairy
                    ? (byte)15 : Convert.ToByte(block["TYPE"][0][3]);

                FillFlags(item, block["FLAG"][0]);
                FillData(item, block["DATA"][0]);
                Items.Add(item.Id, item);
            }
        }

        private static void FillBuff(IReadOnlyList<string> currentLine, ItemDat item)
        {
            for (int i = 0; i < 5; i++)
            {
                byte type = (byte)int.Parse(currentLine[2 + 5 * i]);
                if (type is 0 or 255) // 255 = -1
                {
                    continue;
                }

                int first = int.Parse(currentLine[3 + 5 * i]);
                int second = int.Parse(currentLine[4 + 5 * i]);

                int firstModulo = first % 4;
                firstModulo = firstModulo switch
                {
                    -1 => 1,
                    -2 => 2,
                    -3 => 1,
                    _ => firstModulo
                };

                int secondModulo = second % 4;
                secondModulo = secondModulo switch
                {
                    -1 => 1,
                    -2 => 2,
                    -3 => 1,
                    _ => secondModulo
                };

                var itemCard = new BCardObject
                {
                    ItemVNum = item.Id,
                    Type = type,
                    SubType = (byte)((int.Parse(currentLine[5 + i * 5]) + 1) * 10 + 1 + (first < 0 ? 1 : 0)),
                    FirstDataScalingType = (BCardScalingType)firstModulo,
                    SecondDataScalingType = (BCardScalingType)secondModulo,
                    FirstData = (int)Math.Abs(Math.Floor(first / 4.0)),
                    SecondData = (int)Math.Abs(Math.Floor(second / 4.0)),
                    CastType = byte.Parse(currentLine[6 + 5 * i])
                };

                item.BCards.Add(itemCard);
            }
        }

        private static void FillFlags(ItemDat item, IReadOnlyList<string> currentLine)
        {
            // useless [2]
            // useless [3]
            // useless [4]
            item.IsSoldable = currentLine[5] == "0";
            item.IsDroppable = currentLine[6] == "0";
            item.IsTradable = currentLine[7] == "0";
            item.IsMinilandActionable = currentLine[8] == "1";
            item.IsWarehouse = currentLine[9] == "1";
            item.ShowWarningOnUse = currentLine[10] == "1";
            item.IsTimeSpaceRewardBox = currentLine[11] == "1";
            item.ShowDescriptionOnHover = currentLine[12] == "1";
            item.Flag3 = currentLine[13] == "1";
            item.FollowMouseOnUse = currentLine[14] == "1";
            item.ShowSomethingOnHover = currentLine[15] == "1";
            item.IsColorable = currentLine[16] == "1";
            item.Sex = currentLine[18] == "1" ? (byte)1 : currentLine[17] == "1" ? (byte)2 : (byte)0;
            //not used item.Flag6 = currentLine[19] == "1";
            item.PlaySoundOnPickup = currentLine[20] == "1";
            item.UseReputationAsPrice = currentLine[21] == "1";
            if (item.UseReputationAsPrice)
            {
                item.ReputPrice = item.Price;
            }

            item.IsHeroic = currentLine[22] == "1";
            item.Flag7 = currentLine[23] == "1";
            item.IsLimited = currentLine[24] == "1";
        }

        private static void FillData(ItemDat item, string[] currentLine)
        {
            item.Data = new int[20];

            for (int i = 0; i < 20; i++)
            {
                item.Data[i] = Convert.ToInt32(currentLine[2 + i]);
            }

            switch (item.ItemType)
            {
                case ItemType.Weapon:
                    item.LevelMinimum = Convert.ToByte(currentLine[2]);
                    item.DamageMinimum = Convert.ToInt16(currentLine[3]);
                    item.DamageMaximum = Convert.ToInt16(currentLine[4]);
                    item.HitRate = Convert.ToInt16(currentLine[5]);
                    item.CriticalLuckRate = Convert.ToSByte(currentLine[6]);
                    item.CriticalRate = Convert.ToInt16(currentLine[7]);
                    item.BasicUpgrade = Convert.ToByte(currentLine[10]);
                    item.MaximumAmmo = 100;
                    break;

                case ItemType.Armor:
                    item.LevelMinimum = Convert.ToByte(currentLine[2]);
                    item.CloseDefence = Convert.ToInt16(currentLine[3]);
                    item.DistanceDefence = Convert.ToInt16(currentLine[4]);
                    item.MagicDefence = Convert.ToInt16(currentLine[5]);
                    item.DefenceDodge = Convert.ToInt16(currentLine[6]);
                    item.DistanceDefenceDodge = Convert.ToInt16(currentLine[6]);
                    item.BasicUpgrade = Convert.ToByte(currentLine[10]);
                    break;

                case ItemType.Box:
                    item.Effect = Convert.ToInt16(currentLine[21]);
                    item.EffectValue = Convert.ToInt32(currentLine[3]);
                    item.LevelMinimum = Convert.ToByte(currentLine[4]);

                    if (item.ItemSubType == 7) // Magic Speed Booster
                    {
                        long time = Convert.ToInt32(currentLine[4]);
                        item.ItemValidTime = time == 0 ? -1 : Convert.ToInt32(currentLine[4]) * 3600;
                    }

                    break;

                case ItemType.Fashion:
                    item.LevelMinimum = Convert.ToByte(currentLine[2]);
                    item.CloseDefence = Convert.ToInt16(currentLine[3]);
                    item.DistanceDefence = Convert.ToInt16(currentLine[4]);
                    item.MagicDefence = Convert.ToInt16(currentLine[5]);
                    item.DefenceDodge = Convert.ToInt16(currentLine[6]);
                    item.DistanceDefenceDodge = Convert.ToInt16(currentLine[6]);

                    if (item.EquipmentSlot == EquipmentType.CostumeHat || item.EquipmentSlot == EquipmentType.CostumeSuit || item.EquipmentSlot == EquipmentType.WeaponSkin)
                    {
                        long time = Convert.ToInt32(currentLine[13]);
                        item.ItemValidTime = time == 0 ? -1 : Convert.ToInt32(currentLine[13]) * 3600;
                    }

                    break;

                case ItemType.Food:
                    item.Hp = Convert.ToInt16(currentLine[2]);
                    item.Mp = Convert.ToInt16(currentLine[4]);
                    break;

                case ItemType.Jewelry:
                    switch (item.EquipmentSlot)
                    {
                        case EquipmentType.Amulet:
                            item.LevelMinimum = Convert.ToByte(currentLine[2]);
                            item.ItemLeftType = Convert.ToInt16(currentLine[4]);
                            if (item.ItemLeftType == 100)
                            {
                                item.LeftUsages = Convert.ToInt32(currentLine[3]);
                            }
                            else if (item.ItemLeftType >= 1000)
                            {
                                item.ItemValidTime = Convert.ToInt64(currentLine[13]) * 3600;
                            }
                            else
                            {
                                item.ItemValidTime = Convert.ToInt64(currentLine[3]) == 0 ? -1 : Convert.ToInt64(currentLine[3]) / 10;
                            }

                            break;

                        case EquipmentType.Fairy:
                            item.Element = Convert.ToByte(currentLine[2]);
                            item.ElementRate = Convert.ToInt16(currentLine[3]);
                            if (item.Id <= 256)
                            {
                                item.MaxElementRate = 50;
                            }
                            else if (item.ElementRate == 0)
                            {
                                if (item.Id >= 800 && item.Id <= 804)
                                {
                                    item.MaxElementRate = 50;
                                }
                                else
                                {
                                    item.MaxElementRate = 70;
                                }
                            }
                            else if (item.ElementRate == 30)
                            {
                                item.MaxElementRate = 30;
                            }
                            else if (item.ElementRate == 35)
                            {
                                item.MaxElementRate = 35;
                            }
                            else if (item.ElementRate == 40)
                            {
                                item.MaxElementRate = 70;
                            }
                            else if (item.ElementRate == 50)
                            {
                                item.MaxElementRate = 80;
                            }

                            break;

                        default:
                            item.LevelMinimum = Convert.ToByte(currentLine[2]);
                            item.MaxCellonLvl = Convert.ToByte(currentLine[3]);
                            item.MaxCellon = Convert.ToByte(currentLine[4]);
                            break;
                    }

                    break;

                case ItemType.Event:
                    item.Effect = Convert.ToInt16(currentLine[2]);
                    item.EffectValue = Convert.ToInt16(currentLine[3]);
                    break;

                case ItemType.Special:
                    item.Effect = Convert.ToInt16(currentLine[2]);

                    switch (item.Effect)
                    {
                        case 305:
                            item.EffectValue = Convert.ToInt32(currentLine[5]);
                            item.Morph = Convert.ToInt16(currentLine[4]);
                            break;

                        default:
                            item.EffectValue = item.EffectValue == 0 ? Convert.ToInt32(currentLine[4]) : item.EffectValue;
                            break;
                    }

                    item.WaitDelay = 5000;
                    break;

                case ItemType.Magical:
                    item.Effect = Convert.ToInt16(currentLine[2]);

                    if (item.Effect == 99)
                    {
                        item.LevelMinimum = Convert.ToByte(currentLine[4]);
                        item.EffectValue = Convert.ToByte(currentLine[5]);
                    }
                    else
                    {
                        item.EffectValue = Convert.ToInt32(currentLine[4]);
                    }

                    break;

                case ItemType.Specialist:
                    item.IsPartnerSpecialist = item.ItemSubType == 4;
                    item.Speed = Convert.ToByte(currentLine[5]);
                    if (item.IsPartnerSpecialist)
                    {
                        item.Element = Convert.ToByte(currentLine[3]);
                        item.ElementRate = Convert.ToInt16(currentLine[4]);
                        item.PartnerClass = Convert.ToByte(currentLine[19]);
                        item.LevelMinimum = Convert.ToByte(currentLine[20]);
                    }
                    else
                    {
                        item.LevelJobMinimum = Convert.ToByte(currentLine[20]);
                        item.ReputationMinimum = Convert.ToByte(currentLine[21]);
                    }

                    item.SpPointsUsage = Convert.ToByte(currentLine[13]);
                    item.SpMorphId = item.IsPartnerSpecialist ? (byte)(1 + Convert.ToByte(currentLine[14])) : Convert.ToByte(currentLine[14]);
                    item.FireResistance = Convert.ToByte(currentLine[15]);
                    item.WaterResistance = Convert.ToByte(currentLine[16]);
                    item.LightResistance = Convert.ToByte(currentLine[17]);
                    item.DarkResistance = Convert.ToByte(currentLine[18]);

                    var elementdic = new Dictionary<int, int> { { 0, 0 } };
                    if (item.FireResistance != 0)
                    {
                        elementdic.Add(1, item.FireResistance);
                    }

                    if (item.WaterResistance != 0)
                    {
                        elementdic.Add(2, item.WaterResistance);
                    }

                    if (item.LightResistance != 0)
                    {
                        elementdic.Add(3, item.LightResistance);
                    }

                    if (item.DarkResistance != 0)
                    {
                        elementdic.Add(4, item.DarkResistance);
                    }

                    if (!item.IsPartnerSpecialist)
                    {
                        item.Element = (byte)elementdic.OrderByDescending(s => s.Value).First().Key;
                    }

                    // needs to be hardcoded
                    switch (item.Id)
                    {
                        case 901:
                            item.Element = 1;
                            break;

                        case 903:
                            item.Element = 2;
                            break;

                        case 906:
                        case 909:
                            item.Element = 3;
                            break;
                    }

                    break;

                case ItemType.Shell:
                    byte shellType = Convert.ToByte(currentLine[5]);

                    item.ShellMinimumLevel = Convert.ToInt16(currentLine[3]);
                    item.ShellMaximumLevel = Convert.ToInt16(currentLine[4]);
                    item.ShellType = (ShellType)(item.ItemSubType == 1 ? shellType + 50 : shellType);
                    break;

                case ItemType.Main:
                case ItemType.Upgrade:
                case ItemType.Map:
                case ItemType.Production:
                case ItemType.PetPartnerItem:
                    item.Effect = Convert.ToInt16(currentLine[2]);
                    item.EffectValue = Convert.ToInt32(currentLine[4]);
                    break;

                case ItemType.Potion:
                    item.Hp = Convert.ToInt16(currentLine[2]);
                    item.Mp = Convert.ToInt16(currentLine[4]);
                    break;

                case ItemType.Snack:
                    item.Hp = Convert.ToInt16(currentLine[2]);
                    item.Mp = Convert.ToInt16(currentLine[4]);
                    break;

                case ItemType.Material:
                case ItemType.Sell:
                case ItemType.Quest2:
                case ItemType.Quest1:
                case ItemType.Ammo:
                    // nothing to parse
                    break;
            }

            if (item.Type == InventoryType.Miniland)
            {
                item.MinilandObjectPoint = int.Parse(currentLine[2]);
                item.EffectValue = short.Parse(currentLine[8]);
                item.Width = Convert.ToByte(currentLine[9]) == 0 ? (byte)1 : Convert.ToByte(currentLine[9]);
                item.Height = Convert.ToByte(currentLine[10]) == 0 ? (byte)1 : Convert.ToByte(currentLine[10]);
            }

            if (item.EquipmentSlot != EquipmentType.Boots && item.EquipmentSlot != EquipmentType.Gloves || item.Type != 0)
            {
                return;
            }

            item.FireResistance = Convert.ToByte(currentLine[7]);
            item.WaterResistance = Convert.ToByte(currentLine[8]);
            item.LightResistance = Convert.ToByte(currentLine[9]);
            item.DarkResistance = Convert.ToByte(currentLine[11]);
        }

        private static void FillMorphAndIndexValues(string[] currentLine, ItemDat item)
        {
            item.Type = Convert.ToByte(currentLine[2]) switch
            {
                4 => InventoryType.Equipment,
                8 => InventoryType.Equipment,
                9 => InventoryType.Main,
                10 => InventoryType.Etc,
                _ => (InventoryType)Enum.Parse(typeof(InventoryType), currentLine[2]),
            };
            item.ItemType = currentLine[3] != "-1" ? (ItemType)Enum.Parse(typeof(ItemType), $"{(short)item.Type}{currentLine[3]}") : ItemType.Weapon;
            item.ItemSubType = Convert.ToByte(currentLine[4]);
            item.EquipmentSlot = (EquipmentType)Enum.Parse(typeof(EquipmentType), currentLine[5] != "-1" ? currentLine[5] : "0");

            item.IconId = Convert.ToInt32(currentLine[6]);
            switch (item.Id)
            {
                case 4101:
                case 4102:
                case 4103:
                case 4104:
                case 4105:
                    item.EquipmentSlot = 0;
                    break;

                default:
                    if (item.EquipmentSlot.Equals(EquipmentType.Amulet))
                    {
                        item.EffectValue = item.Id switch
                        {
                            4503 => 4544,
                            4504 => 4294,
                            _ => Convert.ToInt16(currentLine[7]),
                        };
                    }
                    else
                    {
                        item.Morph = Convert.ToInt16(currentLine[7]);
                    }

                    break;
            }
        }
    }
}