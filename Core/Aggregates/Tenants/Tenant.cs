using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Geex.Common.Abstraction.MultiTenant;
using Geex.Common.Abstraction.Storage;
using Geex.Common.MultiTenant.Api.Aggregates.Tenants;


namespace Geex.Common.MultiTenant.Core.Aggregates.Tenants
{
    public class Tenant : Entity, ITenant
    {
        public string Code { get; set; }

        /// <inheritdoc />
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        internal static Tenant Create(string code, string name, Dictionary<string, object> externalInfo = default)
        {
            return new Tenant()
            {
                Code = code,
                Name = name,
                IsEnabled = true,
                ExternalInfo = externalInfo ?? new()
            };
        }

        public override async Task<ValidationResult> Validate(IServiceProvider sp, CancellationToken cancellation = default)
        {
            return ValidationResult.Success;
        }

        /// <inheritdoc />
        public Dictionary<string, object> ExternalInfo { get; set; } = new();
    }
}
