using System.Text.Json;
using System.Web;
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

        public static string BuildGetApplicationsQueryString(GetApplicationsQuery queryParams)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            query["page"] = queryParams.Page.ToString();
            query["page_size"] = queryParams.PageSize.ToString();

            if (!string.IsNullOrEmpty(queryParams.OrderBy)) query["order_by"] = queryParams.OrderBy;
            if (!string.IsNullOrEmpty(queryParams.Order)) query["order"] = queryParams.Order;
            if (!string.IsNullOrEmpty(queryParams.Status)) query["status"] = queryParams.Status;
            if (!string.IsNullOrEmpty(queryParams.ApplicationType)) query["application_type"] = queryParams.ApplicationType;
            if (queryParams.TermsAccepted.HasValue) query["terms_and_conditions_accepted"] = queryParams.TermsAccepted.Value.ToString().ToLower();
            if (!string.IsNullOrEmpty(queryParams.CustomerId)) query["customer_id"] = queryParams.CustomerId;
            if (!string.IsNullOrEmpty(queryParams.CustomerName)) query["customer_name"] = queryParams.CustomerName;
            if (!string.IsNullOrEmpty(queryParams.EmailAddress)) query["email_address"] = queryParams.EmailAddress;

            return query.ToString() ?? string.Empty; // Ensure a non-null string is returned
        }
    }
}
