using System;

namespace NotionAPI.Models
{
    public class NotionClientError : NotionObject
    {
        public string Message { get; }

        public Exception Exception { get; }

        public NotionClientError(string message = "")
        {
            Message = message;
        }

        public NotionClientError(Exception exception)
        {
            Exception = exception;
            Message = exception.Message;
        }
    }
}
