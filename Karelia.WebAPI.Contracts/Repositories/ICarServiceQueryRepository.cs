using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="CarServiceQuery"/> entity
    /// </summary>
    public interface ICarServiceQueryRepository : IClassicQueryRepository<CarServiceQuery, int>
    {
    }
}