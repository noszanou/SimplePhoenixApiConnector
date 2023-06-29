namespace Shared.PhoenixAPI.Enums
{
    public enum ObjectType
    {
        packet_send,        // 0
        packet_recv,        // 1
        attack,             // 2
        player_skill,       // 3
        player_walk,        // 4
        pet_skill,          // 5
        partner_skill,      // 6
        pets_walk,          // 7
        pick_up,            // 8
        collect,            // 9
        start_bot,          // 10
        stop_bot,           // 11
        continue_bot,       // 12
        load_settings,      // 13
        start_minigame_bot, // 14
        stop_minigame_bot,  // 15
        query_player_info,  // 16
        query_inventory,    // 17
        query_skills_info,  // 18
        query_map_entities  // 19
    }
}