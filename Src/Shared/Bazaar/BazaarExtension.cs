using Shared.Bazaar.Enums;
using Shared.DatEntity;
using Shared.DatEntity.Enums.Items;
using Shared.PhoenixAPI.ClientToBot;
using SuperSimpleTcp;
using Shared;
using Shared.PhoenixAPI.PhoenixEntitys;
using Shared.DatEntity.Manager;

namespace Shared.Bazaar
{
    public static class BazaarExtension
    {
        public static (byte category, byte subCategory) GetBazaarInfoItem(this Item itemjs, SimpleTcpClient xd, IBotConfiguration _conf, IItemManager manager)
        {
            if (!itemjs.Vnum.HasValue) return (0,0);

            var item = manager.Items[itemjs.Vnum.Value];
            // Missing item parsed ( probably i will add it or no ? c: )
            // ( Parsed with e_info )
            // Specialist
            // Pet ?
            // Npc
            // Vehicle

            if (item.Type == InventoryType.Equipment)
            {
                switch (item.ItemType)
                {
                    case ItemType.Weapon:
                    case ItemType.Armor:
                        return item.Class switch
                        {
                            4 => ((byte)(item.ItemType + 1), (byte)WeaponSub.Archer),
                            8 => ((byte)(item.ItemType + 1), (byte)WeaponSub.Mage),
                            1 => ((byte)(item.ItemType + 1), (byte)WeaponSub.Adventurer),
                            16 => ((byte)(item.ItemType + 1), (byte)WeaponSub.MartialArtist),
                            _ => ((byte)(item.ItemType + 1), (byte)WeaponSub.Swordman),
                        };

                    case ItemType.Fashion:
                        return item.EquipmentSlot switch
                        {
                            EquipmentType.Mask => ((byte)BazaarListType.Equipment, (byte)FashionSub.Fantasy),
                            EquipmentType.CostumeHat => ((byte)BazaarListType.Equipment, (byte)FashionSub.CostumeHat),
                            EquipmentType.CostumeSuit => ((byte)BazaarListType.Equipment, (byte)FashionSub.CostumeSuit),
                            EquipmentType.Gloves => ((byte)BazaarListType.Equipment, (byte)FashionSub.Gloves),
                            EquipmentType.WingsSkin => ((byte)BazaarListType.Equipment, (byte)FashionSub.CostumeWings),
                            EquipmentType.Boots => ((byte)BazaarListType.Equipment, (byte)FashionSub.Boots),
                            _ => ((byte)BazaarListType.Equipment, (byte)FashionSub.Hat),
                        };

                    case ItemType.Jewelry:

                        return item.EquipmentSlot switch
                        {
                            EquipmentType.Amulet => ((byte)BazaarListType.Jewelery, (byte)JewelerySub.Amulet),
                            EquipmentType.Fairy => ((byte)BazaarListType.Jewelery, (byte)JewelerySub.Fairy),
                            EquipmentType.Bracelet => ((byte)BazaarListType.Jewelery, (byte)JewelerySub.Bracelet),
                            EquipmentType.Ring => ((byte)BazaarListType.Jewelery, (byte)JewelerySub.Ring),
                            _ => ((byte)BazaarListType.Jewelery, (byte)JewelerySub.Necklace),
                        };

                    case ItemType.Box:

                        // ISSSSOUUUUU
                        if (item.ItemSubType == 0) // Pet
                        {
                            if (item.Effect == 0) // Pet bead
                            {
                                if (_conf.LatestEinfoReceived == null)
                                {
                                    xd.SendPacketToServer($"eqinfo 1 {itemjs.Position}");
                                }
                                
                                while(!_conf.LatestEinfoReceived.Packet.Contains(item.Id.ToString()))
                                {
                                    xd.SendPacketToServer($"eqinfo 1 {itemjs.Position}");
                                }
                                var hodlingVnum = _conf.LatestEinfoReceived.Packet.Split(' ')[3];
                                if (hodlingVnum == "0")
                                {
                                    return ((byte)BazaarListType.Pet, (byte)PetSub.BeadEmpty);
                                }
                                return ((byte)BazaarListType.Pet, (byte)PetSub.BeadWithPet);
                            }
                            else
                            {
                                return ((byte)BazaarListType.Pet, (byte)PetSub.BeadWithPet);
                            }
                        }

                        if (item.Type == InventoryType.Equipment && item.ItemType == ItemType.Box && !item.ShowWarningOnUse)
                        {
                            return ((byte)BazaarListType.Other, (byte)OtherSub.All);
                        }

                        if (item.ItemSubType == 5) // fairy bead
                        {
                            return ((byte)BazaarListType.Jewelery, (byte)JewelerySub.Fairy);
                        }
                        break;

                    case ItemType.Shell:
                        return item.ItemSubType switch
                        {
                            1 => ((byte)BazaarListType.Shell, (byte)ShellSub.ArmorShell),
                            _ => ((byte)BazaarListType.Shell, (byte)ShellSub.WeaponShell),
                        };
                }
            }

            if (item.Type == InventoryType.Etc)
            {
                switch (item.ItemType)
                {
                    case ItemType.Food:
                        return ((byte)BazaarListType.Usable, (byte)UsableSub.Food);
                    case ItemType.Snack:
                        return ((byte)BazaarListType.Usable, (byte)UsableSub.Snacks);
                    case ItemType.Magical:
                        return ((byte)BazaarListType.Usable, (byte)UsableSub.MagicalItem);
                    case ItemType.Material:
                        return ((byte)BazaarListType.Usable, (byte)UsableSub.MaterialItem);
                    case ItemType.PetPartnerItem:
                        return ((byte)BazaarListType.Usable, (byte)UsableSub.NosMateItem);
                    case ItemType.Sell:
                        return ((byte)BazaarListType.Usable, (byte)UsableSub.SellableItem);
                }
            }

            if (item.Type == InventoryType.Main)
            {
                switch (item.ItemType)
                {
                    case ItemType.Main:
                        return ((byte)BazaarListType.Main, (byte)MainSub.NormalItem);
                    case ItemType.Upgrade:
                        return ((byte)BazaarListType.Main, (byte)MainSub.UpgradeItem);
                    case ItemType.Production:
                        return ((byte)BazaarListType.Main, (byte)MainSub.Item);
                    case ItemType.Special:
                        return ((byte)BazaarListType.Main, (byte)MainSub.SpecialItem);
                    case ItemType.Potion:
                        return ((byte)BazaarListType.Main, (byte)MainSub.PotionItem);
                    case ItemType.Event:
                        return ((byte)BazaarListType.Main, (byte)MainSub.EventItem);
                    case ItemType.Title:
                        return ((byte)BazaarListType.Main, (byte)MainSub.TitleItem);
                }
            }

            return (1, 1);
        }
    }
}
