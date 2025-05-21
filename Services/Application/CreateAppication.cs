using RailAPI.Core;
using RailAPI.Models.Application;

namespace RailAPI.Services.Application
{
    public class CreateAppication
    {

        // Create application
        public async Task<ApplicationResponse> CreateApplicationAsync(string accessToken)
        {

            // Prepare the payload
            var payload = Payload.PrepareRequestPayload();

            // create the headers
            var headers = new Dictionary<string, string>
                                                {
                                                    { "x-l2f-request-id", Guid.NewGuid().ToString() },
                                                    { "x-l2f-idempotency-id", Guid.NewGuid().ToString() }
                                                };

            // prepare the request
            var request = DefaultHttpRequestBuilder.BuildPostRequest(url: "", payload: payload, 
                                                accessToken: accessToken, headers: headers);

            // Send the request
            var response = await ApiRequest.SendPostRequestAsync<ApplicationResponse>(request);

            // return the response
            return response!;
        }

    }
}
