using RailAPI.Core;
using RailAPI.Models.Application;

namespace RailAPI.Services.Application
{
    public class SubmitApplicationService
    {
        public async Task<SubmitApplicationResponse> SubmitApplicationAsync(string accessToken, string applicationId)
        {
            // Construct the URL with path parameter
            var url = $"https://api.rail.io/v1/applications/{applicationId}/submit";

            // Prepare headers
            var headers = new Dictionary<string, string>
            {
                { "x-l2f-request-id", Guid.NewGuid().ToString() },
                { "x-l2f-idempotency-id", Guid.NewGuid().ToString() }
            };

            // Build POST request
            var request = DefaultHttpRequestBuilder.BuildPostRequest(
                url: url,
                accessToken: accessToken,
                headers: headers,
                payload: "" // No body for this request
            );

            // Send POST request
            var response = await ApiRequest.SendPostRequestAsync<SubmitApplicationResponse>(request);

            return response!;
        }
    }
}
