using System.Text.Json.Serialization;

namespace RailAPI.Models.Application
{
    public class KycProfile
    {
        [JsonPropertyName("funds_send_receive_jurisdictions")]
        public required List<string> FundsSendReceiveJurisdictions { get; set; }

        [JsonPropertyName("engage_in_activities")]
        public required List<string> EngageInActivities { get; set; }

        [JsonPropertyName("vendors_and_counterparties")]
        public required List<string> VendorsAndCounterparties { get; set; }
    }
}
