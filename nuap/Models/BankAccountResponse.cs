namespace nuap.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class BankAccountResponse
    {
        [JsonProperty(PropertyName = "data")]
        public BankAccount Data { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public List<GeneralError> Errors { get; set; }
    }
}
