using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geex.Common.Abstraction.Gql.Types;
using Geex.Common.Abstraction.MultiTenant;
using Geex.Common.MultiTenant.Api.Aggregates.Tenants;
using Geex.Common.MultiTenant.Api.Aggregates.Tenants.Requests;

using HotChocolate;
using HotChocolate.Types;

using MediatR;

namespace Geex.Common.MultiTenant.Gql.Schemas
{
    public class TenantMutation : MutationExtension<TenantMutation>
    {
        private readonly IMediator _mediator;

        public TenantMutation(IMediator mediator)
        {
            this._mediator = mediator;
        }

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
        public async Task<ITenant> CreateTenant(CreateTenantRequest input)
        {
            var result = await _mediator.Send(input);
            return result;
        }

        /// <summary>
        /// 编辑Tenant
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> EditTenant(
            EditTenantRequest input)
        {
            var result = await _mediator.Send(input);
            return true;
        }

        /// <summary>
        /// 切换Tenant可用状态
        /// </summary>
        /// <returns>当前租户的可用性</returns>
        public async Task<bool> ToggleTenantAvailability(
            ToggleTenantAvailabilityRequest input)
        {
            var result = await _mediator.Send(input);
            return true;
        }
    }
}
