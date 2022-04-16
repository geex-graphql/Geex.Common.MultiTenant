using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Geex.Common.MultiTenant.Api.Aggregates.Tenants.Requests
{
    public record CreateTenantRequest : IRequest<ITenant>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Dictionary<string, object> ExternalInfo { get; set; }

    }
}
