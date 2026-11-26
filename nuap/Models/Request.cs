using Newtonsoft.Json;

namespace nuap.Models
{
    public class Request
    {

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public string Balance { get; set; }
    }
}
