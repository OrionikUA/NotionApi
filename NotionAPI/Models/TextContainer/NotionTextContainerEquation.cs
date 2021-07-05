using Newtonsoft.Json;

namespace NotionAPI.Models.TextContainer
{
    public class NotionTextContainerEquation : NotionTextContainer
    {
        [JsonProperty("equation", Order = 1)]
        public NotionEquation Equation { get; set; }
    }
}
