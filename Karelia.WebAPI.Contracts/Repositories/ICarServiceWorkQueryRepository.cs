using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="CarServiceWorkQuery"/> entity
    /// </summary>
    public interface ICarServiceWorkQueryRepository : IClassicQueryRepository<CarServiceWorkQuery, int>
    {
    }
}