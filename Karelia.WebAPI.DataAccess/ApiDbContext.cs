using BusinessFramework.WebAPI.Data;
using BusinessFramework.WebAPI.Data.ChangeTracking;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.DataAccess.Mapping;

namespace Karelia.WebAPI.DataAccess
{
    /// <summary>
    /// Api db context
    /// </summary>
    public sealed partial class ApiDbContext : ObjectBaseDbContext, IApiDbContext
    {
        /// <summary>
        ///     Ctor
        /// </summary>
        public ApiDbContext(IDatabaseContextFactory factory, IChangeTrackingManager changeTrackingManager, string nameOrConnectionString)
            : base(factory, changeTrackingManager, ApiDbContextMapping.OnModelCreating, nameOrConnectionString)
        {
        }
    }
}