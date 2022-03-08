using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geex.Common.MultiTenant.Api.Aggregates.Tenants;

namespace Geex.Common.MultiTenant.Api
{
    public interface ICurrentTenant
    {
        public string? Code { get; }
        public ITenant Detail { get; }
        public IDisposable Change(string? tenantCode);
    }
}
