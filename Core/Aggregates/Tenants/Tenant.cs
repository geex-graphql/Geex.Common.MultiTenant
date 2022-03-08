using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        internal static Tenant Create(string code, string name)
        {
            return new Tenant()
            {
                Code = code,
                Name = name,
                IsEnabled = true,
            };
        }

        /// <inheritdoc />
        public Dictionary<string, object> ExternalInfo { get; set; } = new ();
    }
}
