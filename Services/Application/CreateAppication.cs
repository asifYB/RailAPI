using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RailAPI.Core;
using RailAPI.Models.Application;

namespace RailAPI.Services.Application
{
    public class CreateAppication
    {

        private ApiRequestAsync _apiRequestAsync;

        public CreateAppication() {

            _apiRequestAsync = new ApiRequestAsync();
        }

        // Create application
        public async Task<ApplicationResponse> CreateApplicationAsync(string accessToken)
        {

            // Prepare the payload
            var payload = Payload.PrepareRequestPayload();

            // prepare the request
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "https://sandbox.layer2financial.com/api/v1/applications")
            {
                Content = content
            };

            // Add headers
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer ", accessToken);
            request.Headers.Add("x-l2f-request-id", Guid.NewGuid().ToString());
            request.Headers.Add("x-l2f-idempotency-id", Guid.NewGuid().ToString());

            // Send the request
            var response = await _apiRequestAsync.SendPostRequestAsync<ApplicationResponse>(request);

            // return the response
            return response!;
        }

    }
}
