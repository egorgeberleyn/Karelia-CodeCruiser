using BusinessFramework.WebAPI.Contracts.Data;

namespace Karelia.WebAPI.Contracts
{
    public interface IApiDbContext : IDbContext, IApiEntityManager
    {
    }
}