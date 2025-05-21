using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
