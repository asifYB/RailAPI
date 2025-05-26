using RailAPI.Auth;

namespace RailAPI
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            
            string accessToken = await new OAuth2Client().GetAccessTokenAsync(scopes: "customers:read accounts:read");
            Console.Write(accessToken);
        }
    }
}
