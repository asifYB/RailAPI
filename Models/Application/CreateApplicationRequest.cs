using System.Text.Json.Serialization;

namespace RailAPI.Models.Application
{
    public class CreateApplicationRequest
    {
        [JsonPropertyName("application_type")]
        public required string ApplicationType { get; set; }

        [JsonPropertyName("account_to_open")]
        public required AccountToOpen AccountToOpen { get; set; }

        [JsonPropertyName("terms_and_conditions_accepted")]
        public bool TermsAndConditionsAccepted { get; set; }

        [JsonPropertyName("information_attested")]
        public bool InformationAttested { get; set; } = true;

        [JsonPropertyName("customer_id")]
        public required string CustomerId { get; set; }

        [JsonPropertyName("customer_details")]
        public CustomerDetails? CustomerDetails { get; set; }
    }
}
