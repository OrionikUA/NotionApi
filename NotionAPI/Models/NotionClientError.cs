namespace NotionAPI.Models
{
    public class NotionClientError : NotionObject
    {        
        public string Message { get; set; }

        public NotionClientError(string message = "")
        {
            Message = message;
        }
    }
}
