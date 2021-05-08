using System.Collections.Generic;
using DigitalMenu.Core.Enum;
using Newtonsoft.Json;

namespace DigitalMenu.Core.Model.ApiReturn
{
    public class DMReturn
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string InternalMessage { get; set; }

        public bool Success { get; set; }
        public int Code { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }

        public ErrorCodes? ErrorCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<DMReturnError> Errors { get; set; }
    }

    public class DMReturnPagedData<T>
    {
        public int PageCount { get; set; }
        public int ItemCount { get; set; }
        public int CurrentPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public List<T> Items { get; set; }
    }

    public class DMReturnError
    {
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string InternalMessage { get; set; }
    }
}