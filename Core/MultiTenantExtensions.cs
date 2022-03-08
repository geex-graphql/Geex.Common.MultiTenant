﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Geex.Common.Abstraction.MultiTenant;
using Geex.Common.Abstractions;
using Geex.Common.MultiTenant.Api;

using Microsoft.Extensions.DependencyInjection;

using MongoDB.Entities.Interceptors;

namespace Geex.Common.MultiTenant.Core
{
    public static class MultiTenantExtensions
    {
        public static IServiceCollection AddMultiTenant(this IServiceCollection services)
        {
            services.AddScoped<ICurrentTenant, CurrentTenant>();
            services.AddScoped<ICurrentTenantResolver, CurrentTenantResolver>();
            services.AddScoped<IDataFilter<ITenantFilteredEntity>, TenantDataFilter>(x => new TenantDataFilter(x.GetService<LazyFactory<ICurrentTenant>>()));
            services.AddScoped<ISaveInterceptor<ITenantFilteredEntity>, TenantSaveInterceptor>(x => new TenantSaveInterceptor(x.GetService<LazyFactory<ICurrentTenant>>()));
            return services;
        }
    }
}
