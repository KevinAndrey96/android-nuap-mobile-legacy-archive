namespace nuap.Models
{
    using Newtonsoft.Json;

    public class Payment
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "request_date")]
        public string RequestDate { get; set; }

        [JsonProperty(PropertyName = "payment_date")]
        public string PaymentDate { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "voucher")]
        public string Voucher { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "status_text")]
        public string StatusText { get; set; }

        [JsonProperty(PropertyName = "status_color")]
        public string StatusColor { get; set; }
    }
}
