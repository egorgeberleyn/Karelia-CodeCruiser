using BusinessFramework.WebAPI.Contracts.Data;
using BusinessFramework.WebAPI.Data;
using BusinessFramework.WebAPI.Data.ChangeTracking;
using BusinessFramework.WebAPI.Data.EntityFramework;
using FutureTechnologies.DI.Contracts;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.DataAccess;
using MySql.Data.EntityFramework;
using Npgsql;
using Oracle.ManagedDataAccess.EntityFramework;


namespace Karelia.WebApiServer
{
    internal static partial class DependencyInjectionConfig
    {
        public static void ConfigureDbContext(IServerContainerRegistrator registrator)
        {
#pragma warning disable 168
            MySqlConnectionFactory mySqlConnectionFactory;
#pragma warning restore 168
#pragma warning disable 168
            NpgsqlConnectionFactory npgsqlConnectionFactory;
#pragma warning restore 168
#pragma warning disable 168
            OracleConnectionFactory oracleConnectionFactory;
#pragma warning restore 168

            registrator.Singleton<IDatabaseContextFactory, DatabaseContextFactory>();
            
            registrator.PerRequest<IDbContext, IApiDbContext, IEntityManager, IApiEntityManager, ApiDbContext>(new Parameter("nameOrConnectionString", "Default"));
            registrator.PerRequest<IChangeTrackingManager, ChangeTrackingManager>();
        }
    }
}