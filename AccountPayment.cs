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
                ""customer_id"": ""cust-002"",
                ""account_to_open"": {
                    ""account_id"": ""acc_456"",
                    ""product_id"": ""PAYMENT_BASIC"",
                    ""asset_type_id"": ""FIAT_TESTNET_USD""
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

        public static async Task GetPaymentAccountAsync(string accountId, string accessToken, string requestId)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://sandbox.layer2financial.com/api/v1/accounts/payments/{accountId}");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            if (!string.IsNullOrEmpty(requestId))
                request.Headers.Add("x-l2f-request-id", requestId);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {error}");
                throw new Exception($"Failed to retrieve payment account. Status: {response.StatusCode}, Error: {error}");
            }
        }
    }
}
