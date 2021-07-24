using System;

namespace NotionAPI.Models
{
    public class NotionResult<T> where T : NotionObject
    {
        public string[] Warnings { get; } = new string[0];
        public string[] Errors { get; } = new string[0];
        public NotionObject ActualObject { get; }

        public bool HasResult => Result != null;
        public bool HasClientError => ClientError != null;
        public bool HasApiError => ApiError != null;
        public bool NotParsed => !HasResult && !HasClientError && !HasApiError;

        public T Result => ActualObject as T;
        public NotionError ApiError => ActualObject as NotionError;
        public NotionClientError ClientError => ActualObject as NotionClientError;        
        
        public bool HasResultErrors => Errors.Length > 0;
        public bool HasResultWarnings => Warnings.Length > 0;        

        internal NotionResult(NotionObject obj)
        {
            ActualObject = obj;
            if (obj is T rObj)
            {
                rObj.WriteErrorsAndWarnings(typeof(T).ToString(), out var errors, out var warnings);
                Errors = errors;
                Warnings = warnings;
            }
        }
    }
}
