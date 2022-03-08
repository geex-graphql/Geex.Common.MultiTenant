using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geex.Common.Authorization;

using HotChocolate.AspNetCore.Authorization;

namespace Geex.Common.MultiTenant.Api
{
    public class MultiTenantPermissions : AppPermission<MultiTenantPermissions>
    {
        /// <inheritdoc />
        public MultiTenantPermissions(string value) : base(value)
        {
        }
        public class TenantPermissions : MultiTenantPermissions
        {
            //public static TenantPermissions Query { get; } = new("multiTenant_query_tenants");
            public static TenantPermissions Create { get; } = new("multiTenant_mutation_createTenant");
            public static TenantPermissions Edit { get; } = new("multiTenant_mutation_editTenant");
            public static TenantPermissions Delete { get; } = new("multiTenant_mutation_deleteTenant");

            /// <inheritdoc />
            public TenantPermissions(string value) : base(value)
            {
            }
        }
    }
}
