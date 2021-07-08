using System;
using Newtonsoft.Json;

namespace NotionAPI.Models.User
{
    public class NotionUserBot : NotionUser
    {
        [JsonProperty("bot", Order = 5)]
        public object Person { get; set; } = new object();
    }
}
