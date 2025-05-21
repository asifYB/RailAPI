using System.Text.Json.Serialization;

namespace RailAPI.Models.Application
{
    public class InvestmentProfile
    {
        [JsonPropertyName("primary_source_of_funds")]
        public string? PrimarySourceOfFunds { get; set; }

        [JsonPropertyName("primary_source_of_funds_description")]
        public string? PrimarySourceOfFundsDescription { get; set; }

        [JsonPropertyName("total_assets")]
        public string? TotalAssets { get; set; }

        [JsonPropertyName("usd_value_of_fiat")]
        public string? UsdValueOfFiat { get; set; }

        [JsonPropertyName("monthly_deposits")]
        public string? MonthlyDeposits { get; set; }

        [JsonPropertyName("monthly_withdrawals")]
        public string? MonthlyWithdrawals { get; set; }

        [JsonPropertyName("monthly_investment_deposit")]
        public string? MonthlyInvestmentDeposit { get; set; }

        [JsonPropertyName("monthly_investment_withdrawal")]
        public string? MonthlyInvestmentWithdrawal { get; set; }

        [JsonPropertyName("usd_value_of_crypto")]
        public string? UsdValueOfCrypto { get; set; }

        [JsonPropertyName("monthly_crypto_deposits")]
        public string? MonthlyCryptoDeposits { get; set; }

        [JsonPropertyName("monthly_crypto_withdrawals")]
        public string? MonthlyCryptoWithdrawals { get; set; }

        [JsonPropertyName("monthly_crypto_investment_deposit")]
        public string? MonthlyCryptoInvestmentDeposit { get; set; }

        [JsonPropertyName("monthly_crypto_investment_withdrawal")]
        public string? MonthlyCryptoInvestmentWithdrawal { get; set; }
    }
}
