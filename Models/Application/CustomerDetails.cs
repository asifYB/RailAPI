using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RailAPI.Models.Application
{
    public class CustomerDetails
    {
        [JsonPropertyName("first_name")]
        public required string FirstName { get; set; }

        [JsonPropertyName("middle_name")]
        public string? MiddleName { get; set; }

        [JsonPropertyName("last_name")]
        public required string LastName { get; set; }

        [JsonPropertyName("email_address")]
        public required string EmailAddress { get; set; }

        [JsonPropertyName("mailing_address")]
        public MailingAddress? MailingAddress { get; set; }

        [JsonPropertyName("telephone_number")]
        public required string TelephoneNumber { get; set; }

        [JsonPropertyName("tax_reference_number")]
        public string? TaxReferenceNumber { get; set; }

        [JsonPropertyName("passport_number")]
        public string? PassportNumber { get; set; }

        [JsonPropertyName("nationality")]
        public string? Nationality { get; set; }

        [JsonPropertyName("citizenship")]
        public string? Citizenship { get; set; }

        [JsonPropertyName("date_of_birth")]
        public string? DateOfBirth { get; set; } // Format: YYYY-MM-DD

        [JsonPropertyName("us_residency_status")]
        public string? UsResidencyStatus { get; set; }

        [JsonPropertyName("employment_status")]
        public string? EmploymentStatus { get; set; }

        [JsonPropertyName("employment_description")]
        public string? EmploymentDescription { get; set; }

        [JsonPropertyName("employer_name")]
        public string? EmployerName { get; set; }

        [JsonPropertyName("occupation")]
        public string? Occupation { get; set; }

        [JsonPropertyName("investment_profile")]
        public InvestmentProfile? InvestmentProfile { get; set; }

        [JsonPropertyName("kyc_profile")]
        public KycProfile? KycProfile { get; set; }
    }
}
