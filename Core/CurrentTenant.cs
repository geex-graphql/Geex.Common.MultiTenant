using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geex.Common.Abstraction.MultiTenant;
using Geex.Common.MultiTenant.Api;
using Geex.Common.MultiTenant.Api.Aggregates.Tenants;

using Volo.Abp;

namespace Geex.Common.MultiTenant.Core
{
    public class CurrentTenant : ICurrentTenant
    {
        private readonly ICurrentTenantResolver _currentTenantResolver;
        private string? _tenantCode;
        private readonly Queue<string?> _parentScopes = new Queue<string?>();

        /// <inheritdoc />
        public string? Code => _tenantCode ?? _currentTenantResolver.Resolve();

        /// <inheritdoc />
        public ITenant Detail { get; }


        public CurrentTenant(ICurrentTenantResolver currentTenantResolver)
        {
            _currentTenantResolver = currentTenantResolver;
        }
        /// <inheritdoc />
        public virtual IDisposable Change(string? tenantCode)
        {
            return this.SetCurrent(tenantCode);
        }

        private IDisposable SetCurrent(string? tenantCode)
        {
            this._parentScopes.Enqueue(Code);
            this._tenantCode = tenantCode;
            return new DisposeAction(() =>
            {
                _tenantCode = _parentScopes.Dequeue();
            });
        }
    }
}
