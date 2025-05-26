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
                CustomerId = "CUST123421",
                InformationAttested = true,

                AccountToOpen = new AccountToOpen
                {
                    AccountId = "ACC-721",
                    ProductId = "DEPOSIT_BASIC",
                    AssetTypeId = "FIAT_TESTNET_USD"
                },

                CustomerDetails = new CustomerDetails
                {
                    FirstName = "Asif",
                    MiddleName = " ",
                    LastName = "Test"
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
