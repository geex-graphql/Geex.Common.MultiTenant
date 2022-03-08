using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geex.Common.Gql.Roots;
using Geex.Common.MultiTenant.Api.Aggregates.Tenants;
using Geex.Common.MultiTenant.Api.Aggregates.Tenants.Requests;

using HotChocolate;
using HotChocolate.Types;

using MediatR;

namespace Geex.Common.MultiTenant.Gql.Schemas
{
    public class TenantMutation : MutationTypeExtension<TenantMutation>
    {
        /// <inheritdoc />
        protected override void Configure(IObjectTypeDescriptor<TenantMutation> descriptor)
        {
            base.Configure(descriptor);
        }

        /// <summary>
        /// 创建Tenant
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ITenant> CreateTenant(
            [Service] IMediator mediator,
            CreateTenantRequest input)
        {
            var result = await mediator.Send(input);
            return result;
        }

        /// <summary>
        /// 编辑Tenant
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> EditTenant(
            [Service] IMediator mediator,
            EditTenantRequest input)
        {
            var result = await mediator.Send(input);
            return true;
        }

        /// <summary>
        /// 切换Tenant可用状态
        /// </summary>
        /// <returns>当前租户的可用性</returns>
        public async Task<bool> ToggleTenantAvailability(
            [Service] IMediator mediator,
            ToggleTenantAvailabilityRequest input)
        {
            var result = await mediator.Send(input);
            return true;
        }
    }
}
