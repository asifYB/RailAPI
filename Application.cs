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


        public static async Task CreateCorporateApplication(string accessToken, string requestId, string idempotencyId)
        {
            var json = @"
            {
                ""application_type"": ""CORPORATION"",
                ""account_to_open"": {
                    ""account_id"": ""acc_897"",
                    ""product_id"": ""PAYMENT_BASIC"",
                    ""asset_type_id"": ""FIAT_TESTNET_USD""
                },
                ""terms_and_conditions_accepted"": true,
                ""information_attested"": true,
                ""customer_id"": ""cust_self"",
                ""customer_details"": {
                    ""registered_name"": ""TechCorp Inc."",
                    ""trading_name"": ""TechCorp"",
                    ""registered_number"": ""REG1234567"",
                    ""corporate_tax_reference_number"": ""TAX9876543"",
                    ""registered_address"": {
                        ""unit_number"": ""10B"",
                        ""address_line1"": ""456 Corporate Blvd"",
                        ""address_line2"": """",
                        ""address_line3"": """",
                        ""city"": ""San Francisco"",
                        ""state"": ""CA"",
                        ""postal_code"": ""94105"",
                        ""country_code"": ""US""
                    },
                    ""physical_address"": {
                        ""unit_number"": ""10B"",
                        ""address_line1"": ""456 Corporate Blvd"",
                        ""address_line2"": """",
                        ""address_line3"": """",
                        ""city"": ""San Francisco"",
                        ""state"": ""CA"",
                        ""postal_code"": ""94105"",
                        ""country_code"": ""US""
                    },
                    ""telephone_number"": ""+14155552671"",
                    ""website_address"": ""https://techcorp.com"",
                    ""state_of_incorporation"": ""CA"",
                    ""country_of_incorporation"": ""US"",
                    ""corporate_entity_type"": ""C_CORP_PRIVATE"",
                    ""corporate_entity_type_description"": ""Private C Corporation"",
                    ""email_address"": ""info@techcorp.com"",
                    ""established_on"": ""2010-05-15"",
                    ""naics"": ""541512"",
                    ""naics_description"": ""Computer Systems Design Services"",
                    ""investment_profile"": {
                        ""primary_source_of_funds"": ""INVESTMENT"",
                        ""total_investable_assets"": ""UPTO_10K"",
                        ""total_assets"": ""UPTO_10K"",
                        ""asset_allocation_to_crypto"": ""UPTO_10K"",
                        ""investment_experience_crypto"": ""LITTLE"",
                        ""investment_strategy_crypto"": ""LOW_RISK"",
                        ""initial_deposit_source"": ""DEPOSIT"",
                        ""initial_deposit_source_crypto_details"": """",
                        ""initial_deposit_source_fiat_details"": ""Seed Capital"",
                        ""ongoing_deposit_source"": ""REVENUE"",
                        ""frequency_of_crypto_transactions"": ""DAILY"",
                        ""crypto_investment_plans"": ""CUSTODY"",
                        ""investment_proceeds_use"": ""Reinvestment"",
                        ""expected_crypto_assets"": ""UPTO_10K"",
                        ""perform_transfers_with_unhosted_wallets"": true,
                        ""known_unhosted_wallet_addresses"": ""0xabc123..."",
                        ""trades_per_month"": ""UPTO_20"",
                        ""usd_value_of_crypto"": ""UPTO_10K"",
                        ""frequency_of_transactions"": ""DAILY"",
                        ""monthly_crypto_investment_deposit"": ""UPTO_1K"",
                        ""monthly_investment_deposit"": ""UPTO_1K"",
                        ""monthly_crypto_deposits"": ""UPTO_5"",
                        ""monthly_deposits"": ""UPTO_5"",
                        ""monthly_crypto_investment_withdrawal"": ""UPTO_1K"",
                        ""monthly_investment_withdrawal"": ""UPTO_1K"",
                        ""monthly_crypto_withdrawals"": ""UPTO_5"",
                        ""monthly_withdrawals"": ""UPTO_5"",
                        ""trade_internationally"": true,
                        ""trade_jurisdictions"": [""US""]
                    },
                    ""kyc_profile"": {
                        ""primary_business"": ""SOFTWARE"",
                        ""description_of_business_nature"": ""Enterprise blockchain development"",
                        ""is_charitable"": false,
                        ""business_jurisdictions"": [""US""],
                        ""funds_send_receive_jurisdictions"": [""US""],
                        ""new_york_office"": false,
                        ""engage_in_activities"": [""NONE""],
                        ""regulated_status"": ""REGULATED"",
                        ""regulation_agency"": ""SEC"",
                        ""regulation_agency_regulation_number"": ""SEC123456"",
                        ""control_exemption_reason"": ""REGULATED"",
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

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine("Response Body:");
            Console.WriteLine(responseBody);

            try
            {
                using var document = JsonDocument.Parse(responseBody);
                var id = document.RootElement.GetProperty("data").GetProperty("id").GetString();
                Console.WriteLine($"Created Application ID: {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to parse response: " + ex.Message);
            }
        }


        public static async Task CreateApplication(string accessToken, string requestId, string idempotencyId)
        {
            var json = @"
            {
                ""application_type"": ""INDIVIDUAL"",
                ""account_to_open"": {
                    ""account_id"": ""acc_901"",
                    ""product_id"": ""PAYMENT_BASIC"",
                    ""asset_type_id"": ""FIAT_TESTNET_USD""
                },
                ""terms_and_conditions_accepted"": true,
                ""information_attested"": true,
                ""customer_id"": ""cust_012"",
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
                        ""engage_in_activities"": [""FIREARMS""],
                        ""vendors_and_counterparties"": [""CONTRACTORS""]
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
            var applicationId = "bcb0851f-e7d3-41a2-8f67-dcdcfe5d2c3c"; 
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
            var applicationId = "bcb0851f-e7d3-41a2-8f67-dcdcfe5d2c3c";
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

        public static async Task UploadDocument(string accessToken, string requestId, string idempotencyId, string documentId = "fe5d67dc-5bce-475f-bb4d-4fa0be47d59a", string filePath= @"C:\Users\Mohammad Asif\Downloads\closeup.jpg")
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
