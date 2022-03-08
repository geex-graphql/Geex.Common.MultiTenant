using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geex.Common.Abstraction.ExternalInfo;

using MongoDB.Entities;

namespace Geex.Common.MultiTenant.Api.Aggregates.Tenants
{
    public interface ITenant : IEntity, IHasExternalInfo
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}
