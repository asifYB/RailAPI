using System.Text.Json.Serialization;

namespace RailAPI.Models.Application
{
    public class AccountToOpen
    {
        [JsonPropertyName("account_id")]
        public required string AccountId { get; set; }

        [JsonPropertyName("product_id")]
        public required string ProductId { get; set; }

        [JsonPropertyName("asset_type_id")]
        public required string AssetTypeId { get; set; }
    }
}
