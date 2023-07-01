using Shared.Bazaar.Enums;
using Shared.DatEntity;
using Shared.DatEntity.Enums.Items;

namespace Shared.Bazaar
{
    public static class BazaarExtension
    {
        public static (byte category, byte subCategory) GetBazaarInfoItem(this ItemDat item)
        {

            // Missing item parsed ( probably i will add it or no ? c: )
            // ( Parsed with e_info )
            // Specialist
            // Pet
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
