using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailAPI.Models.Application
{
    public class GetApplicationsQuery
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 20;
        public string? OrderBy { get; set; }
        public string? Order { get; set; }
        public string? Status { get; set; }
        public string? ApplicationType { get; set; }
        public bool? TermsAccepted { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? EmailAddress { get; set; }
    }
}
