using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RailAPI
{
    public class AccountDeposit
    {

        public static async Task OpenAccountDeposit(string accessToken, string requestId, string idempotencyId)
        {
            var json = @"
            {
                ""customer_id"": ""SELF"",
                ""account_to_open"": {
                    ""account_id"": ""act_123"",
                    ""product_id"": ""DEPOSIT_BASIC"",
                    ""asset_type_id"": ""FIAT_TESTNET_USD""
                }
            }";

            using var client = new HttpClient();

            // Add headers
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);
            client.DefaultRequestHeaders.Add("x-l2f-idempotency-id", idempotencyId);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://sandbox.layer2financial.com/api/v1/accounts/deposits", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            //create a deosit account - {"data":{"id":"act_123"}}
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
        }


        public static async Task RetrieveAccountDeposit(string accessToken, string requestId, string idempotencyId)
        {
            using var client = new HttpClient();

            // Add headers
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);

            var page = 0;
            var pageSize = 10;
            var customerId = "cust_001";
            var productType = "DEPOSIT";
            var status = "OPEN";

            var queryParams = new List<string>
            {
                $"page={page}",
                $"page_size={pageSize}"
            };

            var queryString = string.Join("&", queryParams);

            var response = await client.GetAsync($"https://sandbox.layer2financial.com/api/v1/accounts/deposits?{queryString}");
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
        }

        public static async Task UpdateAccountDeposit(string accessToken, string requestId, string accountId)
        {
            var json = @"
            {
                ""updates"": [
                    {
                        ""field"": ""status"",
                        ""value"": ""FROZEN""
                    }
                ],
                ""updated_by"": ""admin-system"",
                ""reason"": ""Suspicious activity detected""
            }";

            using var client = new HttpClient();

            // Add headers
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"https://sandbox.layer2financial.com/api/v1/accounts/deposits/{accountId}";
            var response = await client.PatchAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
        }

        public static async Task RequestAddress(string accessToken, string requestId, string idempotencyId, string accountId)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);
            client.DefaultRequestHeaders.Add("x-l2f-idempotency-id", idempotencyId);

            var url = $"https://sandbox.layer2financial.com/api/v1/accounts/deposits/{accountId}/address";

            var response = await client.PostAsync(url, null); // No body required
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
        }


        public static async Task RetrieveTransactionsFromAccountAsync(
        string accessToken,
        string accountId,
        string requestId,
        int page = 0,
        int pageSize = 20,
        string order = "DESC")
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://sandbox.layer2financial.com/api/v1/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            if (!string.IsNullOrEmpty(requestId))
                client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["page"] = page.ToString();
            query["page_size"] = pageSize.ToString();
            query["order"] = order;
            

            var url = $"accounts/deposits/{accountId}/transactions?{query}";

            var response = await client.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseString);
        }


        public static async Task RetrieveTransactionAsync(
        string accessToken,
        string accountId,
        string transactionId,
        string requestId)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://sandbox.layer2financial.com/api/v1/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            if (!string.IsNullOrEmpty(requestId))
                client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);

            var url = $"accounts/deposits/{accountId}/transactions/{transactionId}";

            var response = await client.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseString);
        }
    }
}
