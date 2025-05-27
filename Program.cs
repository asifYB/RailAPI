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

            string accessToken = await new OAuth2Client().GetAccessTokenAsync(scopes: "applications:read");
            Console.Write(accessToken);

            var requestId = Guid.NewGuid().ToString();
            var idempotencyId = Guid.NewGuid().ToString();

            //await Application.CreateApplication(accessToken, requestId, idempotencyId);
            //"{\"data\":{\"id\":\"39c74493-bb01-4cda-aa23-4a6c06b9ad25\"}}"
            //await Application.CheckApplicationStatus(accessToken, requestId, idempotencyId);


            ////For Account Deposits
            //accessToken = await new OAuth2Client().GetAccessTokenAsync(scopes: "accounts:write");
            //await AccountPayment.OpenAccountPayment(accessToken, requestId, idempotencyId);
            //await AccountDeposit.OpenAccountDeposit(accessToken, requestId, idempotencyId);


            ///for update accounts
            //  accessToken = await new OAuth2Client().GetAccessTokenAsync(scopes: "accounts:write");
            //await AccountDeposit.UpdateAccountDeposit(accessToken, requestId, "acc_123");

            //accessToken = await new OAuth2Client().GetAccessTokenAsync(scopes: "accounts:read");
            //await AccountPayment.RetreiveAccountPayment(accessToken, requestId, idempotencyId);
            //await AccountDeposit.RetrieveAccountDeposit(accessToken, requestId, idempotencyId);

            accessToken = await new OAuth2Client().GetAccessTokenAsync(scopes: "accounts:write");
            await AccountDeposit.RequestAddress(accessToken, requestId, idempotencyId, "acc_123");



            ///Customers
            //accessToken = await new OAuth2Client().GetAccessTokenAsync(scopes: "customers:read");
            //await Customers.RetrieveCustomersAsync(accessToken, requestId);

            //accessToken = await new OAuth2Client().GetAccessTokenAsync(scopes: "customers:write");
            //await Customers.AddIndividualToCorporateCustomerAsync(
            //    corporateCustomerId: "corp_123",
            //    accessToken: accessToken,
            //    requestId: requestId,
            //    idempotencyId: idempotencyId
            //);

        }
    }
}
