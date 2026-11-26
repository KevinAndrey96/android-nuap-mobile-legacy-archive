namespace nuap.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class RequestPaymentResponse
    {
        [JsonProperty(PropertyName = "data")]
        public Request Data { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public List<GeneralError> Errors { get; set; }
    }
}
