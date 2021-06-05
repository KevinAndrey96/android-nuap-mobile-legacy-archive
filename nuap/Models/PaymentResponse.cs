namespace nuap.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PaymentResponse
    {
        [JsonProperty(PropertyName = "data")]
        public List<Payment> Data { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public List<GeneralError> Errors { get; set; }
    }
}
