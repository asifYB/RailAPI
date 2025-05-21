using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RailAPI.Models.Application;

namespace RailAPI.Services.Application
{
    public class Payload
    {

        public static string PrepareRequestPayload()
        {
            var request = new CreateApplicationRequest
            {
                ApplicationType = "INDIVIDUAL",
                TermsAndConditionsAccepted = true,
                CustomerId = "CUST-123456",

                AccountToOpen = new AccountToOpen
                {
                    AccountId = "ACC-789",
                    ProductId = "PROD-456",
                    AssetTypeId = "ASSET-001"
                },

                CustomerDetails = new CustomerDetails
                {
                    FirstName = "Alice",
                    MiddleName = "B",
                    LastName = "Smith",
                    EmailAddress = "alice.smith@example.com",
                    TelephoneNumber = "123-456-7890",
                    TaxReferenceNumber = "TX123456",
                    PassportNumber = "P1234567",
                    Nationality = "US",
                    Citizenship = "US",
                    DateOfBirth = "1990-05-10",
                    UsResidencyStatus = "US_CITIZEN",
                    EmploymentStatus = "EMPLOYEE",
                    EmploymentDescription = "Software Engineer",
                    EmployerName = "Tech Solutions Inc",
                    Occupation = "Engineer",

                    MailingAddress = new MailingAddress
                    {
                        UnitNumber = "10A",
                        AddressLine1 = "123 Main St",
                        AddressLine2 = "Suite 400",
                        AddressLine3 = "",
                        City = "New York",
                        State = "NY",
                        PostalCode = "10001",
                        CountryCode = "US"
                    },

                    InvestmentProfile = new InvestmentProfile
                    {
                        PrimarySourceOfFunds = "EMPLOYMENT",
                        PrimarySourceOfFundsDescription = "Full-time employment salary",
                        TotalAssets = "UPTO_100K",
                        UsdValueOfFiat = "UPTO_50K",
                        MonthlyDeposits = "UPTO_10",
                        MonthlyWithdrawals = "UPTO_5",
                        MonthlyInvestmentDeposit = "UPTO_5K",
                        MonthlyInvestmentWithdrawal = "UPTO_2K",
                        UsdValueOfCrypto = "UPTO_10K",
                        MonthlyCryptoDeposits = "UPTO_3",
                        MonthlyCryptoWithdrawals = "UPTO_2",
                        MonthlyCryptoInvestmentDeposit = "UPTO_1K",
                        MonthlyCryptoInvestmentWithdrawal = "UPTO_500"
                    },

                    KycProfile = new KycProfile
                    {
                        FundsSendReceiveJurisdictions = new List<string> { "US", "SG" },
                        EngageInActivities = new List<string> { "TRADING", "SAVINGS" },
                        VendorsAndCounterparties = new List<string> { "BINANCE", "COINBASE" }
                    }
                }
            };

            // Serialize using System.Text.Json
            var json = JsonSerializer.Serialize(request, new JsonSerializerOptions
            {
                PropertyNamingPolicy = null,
                WriteIndented = true
            });

            return json;
        }
    }
}
