using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RailAPI
{
    internal class Application
    {



        public static async Task CreateApplication(string accessToken, string requestId, string idempotencyId)
        {
            var json = @"
            {
                ""application_type"": ""INDIVIDUAL"",
                ""account_to_open"": {
                    ""account_id"": ""acc_456"",
                    ""product_id"": ""PAYMENT_BASIC"",
                    ""asset_type_id"": ""FIAT_TESTNET_USD""
                },
                ""terms_and_conditions_accepted"": true,
                ""information_attested"": true,
                ""customer_id"": ""cust_self"",
                ""customer_details"": {
                    ""first_name"": ""Asif"",
                    ""middle_name"": ""A."",
                    ""last_name"": ""sanbox"",
                    ""email_address"": ""mohdasifsp21@gmail.com"",
                    ""mailing_address"": {
                        ""unit_number"": ""12A"",
                        ""address_line1"": ""123 Main St"",
                        ""address_line2"": """",
                        ""address_line3"": """",
                        ""city"": ""New York"",
                        ""state"": ""NY"",
                        ""postal_code"": ""10001"",
                        ""country_code"": ""US""
                    },
                    ""telephone_number"": ""+1234567890"",
                    ""tax_reference_number"": ""123456789"",
                    ""passport_number"": ""X1234567"",
                    ""nationality"": ""US"",
                    ""citizenship"": [""US""],
                    ""date_of_birth"": ""1996-01-01"",
                    ""us_residency_status"": ""US_CITIZEN"",
                    ""employment_status"": ""EMPLOYEE"",
                    ""employment_description"": """",
                    ""employer_name"": ""TechCorp"",
                    ""occupation"": ""Software Engineer"",
                    ""investment_profile"": {
                        ""primary_source_of_funds"": ""EMPLOYMENT"",
                        ""primary_source_of_funds_description"": """",
                        ""total_assets"": ""UPTO_10K"",
                        ""usd_value_of_fiat"": ""UPTO_10K"",
                        ""monthly_deposits"": ""UPTO_5"",
                        ""monthly_withdrawals"": ""UPTO_5"",
                        ""monthly_investment_deposit"": ""UPTO_1K"",
                        ""monthly_investment_withdrawal"": ""UPTO_1K"",
                        ""usd_value_of_crypto"": ""UPTO_10K"",
                        ""monthly_crypto_deposits"": ""UPTO_5"",
                        ""monthly_crypto_withdrawals"": ""UPTO_5"",
                        ""monthly_crypto_investment_deposit"": ""UPTO_1K"",
                        ""monthly_crypto_investment_withdrawal"": ""UPTO_1K""
                    },
                    ""kyc_profile"": {
                        ""funds_send_receive_jurisdictions"": [""US""],
                        ""engage_in_activities"": [""NONE""],
                        ""vendors_and_counterparties"": [""SELF""]
                    }
                }
            }";


            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);
            client.DefaultRequestHeaders.Add("x-l2f-idempotency-id", idempotencyId);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://sandbox.layer2financial.com/api/v1/applications", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            using var document = JsonDocument.Parse(responseBody);
            var id = document.RootElement.GetProperty("data").GetProperty("id").GetString();
            //1e1b866f-f13f-4c28-9622-05792ebef00c
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response:");
            Console.WriteLine(id);

        }

        public static async Task CheckApplicationStatus(string accessToken, string requestId, string idempotencyId)
        {
            ////check for application status 
            using var client = new HttpClient();
            var applicationId = "39c74493-bb01-4cda-aa23-4a6c06b9ad25"; // Replace with actual Application ID
            requestId = Guid.NewGuid().ToString();
            idempotencyId = Guid.NewGuid().ToString();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);
            client.DefaultRequestHeaders.Add("x-l2f-idempotency-id", idempotencyId);

            var url = $"https://sandbox.layer2financial.com/api/v1/applications/{applicationId}/status";

            var response = await client.GetAsync(url);
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response:");
            Console.WriteLine(responseBody);
        }

        public async Task UpdateApplication(string accessToken, string requestId, string idempotencyId)
        {
            using var client = new HttpClient();
            var applicationId = "571d0ff5-0f93-4d6c-85e4-d4f5c0b43d6a";
            var updates = new[]
             {
                //new { field = "customer_details.employment_status", value = "EMPLOYED" },
                new { field = "customer_details.kyc_profile.vendors_and_counterparties", value = "[\"EMPLOYEES\"]" },
                new { field = "customer_details.kyc_profile.funds_send_receive_jurisdictions", value = "[\"US\"]" },
                new { field = "customer_details.kyc_profile.engage_in_activities", value = "[\"FIREARMS\"]" }
             };

            var payload = JsonSerializer.Serialize(new { updates });
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var url = $"https://sandbox.layer2financial.com/api/v1/applications/{applicationId}";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);
            client.DefaultRequestHeaders.Add("x-l2f-idempotency-id", idempotencyId);

            var response = await client.PatchAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response:");
            Console.WriteLine(responseBody);
        }


        public static async Task SubmitApplication(string accessToken, string requestId, string idempotencyId)
        {
            using var client = new HttpClient();
            var applicationId = "39c74493-bb01-4cda-aa23-4a6c06b9ad25"; // Replace with actual Application ID
            requestId = Guid.NewGuid().ToString();
            idempotencyId = Guid.NewGuid().ToString();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);
            client.DefaultRequestHeaders.Add("x-l2f-idempotency-id", idempotencyId);

            var url = $"https://sandbox.layer2financial.com/api/v1/applications/{applicationId}/submit";

            var response = await client.PostAsync(url, null); // No body is required
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response:");
            Console.WriteLine(responseBody);
        }

        public static async Task RetrieveApplications(string accessToken, string requestId)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);

            // Set query params — adjust values as needed
            var queryParams = new List<string>
            {
                "page=0",
                "page_size=20",
                "order_by=customer_id",
                "order=ASC"
            };

            var queryString = string.Join("&", queryParams);

            var url = $"https://sandbox.layer2financial.com/api/v1/applications?{queryString}";

            var response = await client.GetAsync(url);
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
        }

        public static async Task UploadDocument(string accessToken, string requestId, string idempotencyId, string documentId = "098ca98a-c657-406f-8802-63ab46a908af", string filePath= @"C:\Users\Mohammad Asif\Downloads\Aadhar.pdf")
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("x-l2f-request-id", requestId);
            client.DefaultRequestHeaders.Add("x-l2f-idempotency-id", idempotencyId);

            using var form = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(filePath));
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            form.Add(fileContent, "file", Path.GetFileName(filePath));

            var url = $"https://sandbox.layer2financial.com/api/v1/documents/{documentId}";
            var response = await client.PostAsync(url, form);
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);
        }


    }
}
