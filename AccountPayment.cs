using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RailAPI
{
    public static class AccountPayment
    {
        public static async Task OpenAccountPayment(string accessToken, string requestId, string idempotencyId)
        {
            var json = @"
            {
                ""customer_id"": ""Self"",
                ""account_to_open"": {
                    ""account_id"": ""act_123"",
                    ""product_id"": ""PAYMENT_BASIC"",
                    ""asset_type_id"": ""BITCOIN_TESTNET_BTC""
                }
            }";

            using var client = new HttpClient();

            // Add headers
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);
            client.DefaultRequestHeaders.Add("x-l2f-idempotency-id", idempotencyId);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://sandbox.layer2financial.com/api/v1/accounts/payments", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
        }


        public static async Task RetreiveAccountPayment(string accessToken, string requestId, string idempotencyId)
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

            var response = await client.GetAsync($"https://sandbox.layer2financial.com/api/v1/accounts/payments?{queryString}");
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
        }
    }
}
