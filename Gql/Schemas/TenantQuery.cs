using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geex.Common.Abstraction.Gql.Inputs;
using Geex.Common.Abstraction.Gql.Types;
using Geex.Common.MultiTenant.Api;
using Geex.Common.MultiTenant.Api.Aggregates.Tenants;

using HotChocolate;
using HotChocolate.Types;

using MediatR;

namespace Geex.Common.MultiTenant.Gql.Schemas
{
    public class TenantQuery : QueryExtension<TenantQuery>
    {
        private readonly IMediator _mediator;

        public TenantQuery(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <inheritdoc />
        protected override void Configure(IObjectTypeDescriptor<TenantQuery> descriptor)
        {
            descriptor.Field(x => x.Tenants())
                .UseOffsetPaging()
                .UseFiltering()
                //.Authorize(MultiTenantPermissions.TenantPermissions.Query)
                ;
            base.Configure(descriptor);
        }

        /// <summary>
        /// 列表获取Tenant
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<ITenant>> Tenants()
        {
            var result = await _mediator.Send(new QueryInput<ITenant>());
            return result;
        }

        /// <summary>
        /// 校验Tenant可用性
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CheckTenant(string code)
        {
            var result = await _mediator.Send(new QueryInput<ITenant>(x => x.Code == code && x.IsEnabled));
            return result.Any();
        }
    }
}
