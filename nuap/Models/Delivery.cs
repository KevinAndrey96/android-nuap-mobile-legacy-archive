namespace nuap.Models
{
    using Newtonsoft.Json;

    public class Delivery
    {
        [JsonProperty(PropertyName = "delivery")]
        public string DeliveryTotal { get; set; }

        [JsonProperty(PropertyName = "discount")]
        public string Discount { get; set; }

        [JsonProperty(PropertyName = "total_amount")]
        public string TotalAmount { get; set; }

        [JsonProperty(PropertyName = "total")]
        public string Total { get; set; }
    }
}
