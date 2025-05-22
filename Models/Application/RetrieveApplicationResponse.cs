using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailAPI.Models.Application
{
    public class RetrieveApplicationResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ApplicationType { get; set; } = string.Empty;
        public AccountToOpen AccountToOpen { get; set; } = new()
        {
            AccountId = string.Empty,
            ProductId = string.Empty,
            AssetTypeId = string.Empty
        };
        public bool TermsAndConditionsAccepted { get; set; }
        public string CustomerId { get; set; } = string.Empty;
    }
}
