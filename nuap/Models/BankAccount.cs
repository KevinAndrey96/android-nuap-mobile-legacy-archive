namespace nuap.Models
{
    using Newtonsoft.Json;

    public class BankAccount
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "owner_name")]
        public string OwnerName { get; set; }

        [JsonProperty(PropertyName = "owner_document")]
        public string OwnerDocument { get; set; }

        [JsonProperty(PropertyName = "owner_document_type")]
        public string OwnerDocumentType { get; set; }

        [JsonProperty(PropertyName = "account")]
        public string Account { get; set; }

        [JsonProperty(PropertyName = "account_type")]
        public string AccountType { get; set; }

        [JsonProperty(PropertyName = "bank")]
        public string Bank { get; set; }

        [JsonProperty(PropertyName = "certificate")]
        public string Certificate { get; set; }

        [JsonProperty(PropertyName = "status")]
        public bool Status { get; set; }
    }
}
