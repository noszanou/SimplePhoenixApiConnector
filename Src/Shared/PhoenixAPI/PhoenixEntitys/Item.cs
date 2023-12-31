﻿using Newtonsoft.Json;

namespace Shared.PhoenixAPI.PhoenixEntitys
{
    public class Item
    {
        public Item(short quantity, string name, byte? position, short? vnum, byte? x, byte? y, int? ownerId, int? id)
        {
            Quantity = quantity;
            Name = name;
            Position = position;
            Vnum = vnum;
            X = x;
            Y = y;
            OwnerId = ownerId;
            Id = id;
        }

        [JsonProperty("quantity")]
        public short Quantity { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public byte? Position { get; set; }

        [JsonProperty("vnum", NullValueHandling = NullValueHandling.Ignore)]
        public short? Vnum { get; set; }

        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public byte? X { get; set; }

        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public byte? Y { get; set; }

        [JsonProperty("owner_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? OwnerId { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }
    }
}
