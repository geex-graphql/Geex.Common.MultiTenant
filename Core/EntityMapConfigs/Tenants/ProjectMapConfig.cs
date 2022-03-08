using Geex.Common.Abstraction;
using Geex.Common.MultiTenant.Core.Aggregates.Tenants;

using MongoDB.Bson.Serialization;

namespace Geex.Common.MultiTenant.Core.EntityMapConfigs.Tenants
{
    public class TenantMapConfig : IEntityMapConfig<Tenant>
    {
        public void Map(BsonClassMap<Tenant> map)
        {
            map.AutoMap();
        }
    }
}
