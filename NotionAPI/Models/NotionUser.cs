﻿using System;
using Newtonsoft.Json;

namespace NotionAPI.Models
{
    public class NotionUser : NotionObject, INotionObject, INotionType
    {
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("person")]
        public NotionPerson Person { get; set; }
    }
}
