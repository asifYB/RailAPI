using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RailAPI
{
    public class Customers
    {

        public static async Task RetrieveCustomersAsync(string accesstoken, string requestId)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://sandbox.layer2financial.com/api/v1/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);

            if (!string.IsNullOrEmpty(requestId))
                client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["page"] = "0";
            query["page_size"] = "20"; 

            var url = $"customers?{query}";

            var response = await client.GetAsync(url); 
            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseString);
        }

        public static async Task AddIndividualToCorporateCustomerAsync(string corporateCustomerId, string accessToken, string requestId, string idempotencyId)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://sandbox.layer2financial.com/api/v1/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            if (!string.IsNullOrEmpty(requestId))
                client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);

            if (!string.IsNullOrEmpty(idempotencyId))
                client.DefaultRequestHeaders.Add("x-l2f-idempotency-id", idempotencyId);

            var json = @"
            {
                ""individual_type"": [""OFFICER""],
                ""first_name"": ""John"",
                ""middle_name"": ""H."",
                ""last_name"": ""Doe"",
                ""email_address"": ""john.doe@example.com"",
                ""mailing_address"": {
                    ""address_line_1"": ""123 Main St"",
                    ""address_line_2"": ""Apt 4B"",
                    ""city"": ""New York"",
                    ""region"": ""NY"",
                    ""postal_code"": ""10001"",
                    ""country"": ""US""
                },
                ""telephone_number"": ""+11234567890"",
                ""tax_reference_number"": ""123-45-6789"",
                ""passport_number"": ""X1234567"",
                ""nationality"": ""US"",
                ""citizenship"": [""US""],
                ""date_of_birth"": ""1985-05-15"",
                ""title"": ""CFO"",
                ""us_residency_status"": ""US_CITIZEN""
            }";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"customers/{corporateCustomerId}/individuals", content);

            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {(int)response.StatusCode} {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
        }


        public static async Task CreatePayorAsync(string customerId, string accessToken, string requestId, string idempotencyId)
        {
            var json = @"
            {
                ""id"": ""payor_001"",
                ""first_name"": ""John"",
                ""middle_name"": ""T."",
                ""last_name"": ""Doe"",
                ""email_address"": ""john.doe@example.com"",
                ""phone_number"": ""+11234567890"",
                ""company_name"": ""Example Corp"",
                ""state"": ""NY"",
                ""country_code"": ""US""
            }";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);
            client.DefaultRequestHeaders.Add("x-l2f-idempotency-id", idempotencyId);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"https://sandbox.layer2financial.com/api/v1/customers/{customerId}/payor";
            var response = await client.PostAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
        }


    }
}
