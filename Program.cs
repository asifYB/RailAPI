using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using RailAPI.Auth;
using RailAPI.Services.Application;
using static System.Net.Mime.MediaTypeNames;

namespace RailAPI
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            
            string accessToken = await new OAuth2Client().GetAccessTokenAsync(scopes: "applications:write");
            Console.Write(accessToken);

            var requestId = Guid.NewGuid().ToString();
            var idempotencyId = Guid.NewGuid().ToString();


            //For Account Deposits

        }
    }
}
