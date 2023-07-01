namespace Shared.Bazaar.Enums
{
    // Parse e_info item to see if SpCardBox are empty or not
    public enum NpcSub : byte
    {
        All,
        BeadEmpty,
        BeadWithPartner,
        SpCardEmpty,
        ClosedAttackCard,
        RangedAttackCard,
        MagicalAttackCard
    }
}