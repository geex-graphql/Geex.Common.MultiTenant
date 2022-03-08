using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geex.Common.Abstraction.MultiTenant;
using Geex.Common.Abstractions;
using Geex.Common.MultiTenant.Api;
using MongoDB.Entities.Interceptors;

namespace Geex.Common.MultiTenant.Core
{
    public class TenantSaveInterceptor : SaveInterceptor<ITenantFilteredEntity>
    {
        private readonly LazyFactory<ICurrentTenant> _currentTenant;

        public TenantSaveInterceptor(LazyFactory<ICurrentTenant> currentTenant)
        {
            this._currentTenant = currentTenant;
        }
        /// <inheritdoc />
        public override void Apply(ITenantFilteredEntity entity)
        {
#pragma warning disable CS0618
            entity.SetTenant(_currentTenant.Value.Code);
#pragma warning restore CS0618
        }
    }
}
