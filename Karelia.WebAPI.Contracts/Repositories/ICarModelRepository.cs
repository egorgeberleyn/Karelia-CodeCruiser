using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="CarModel"/> entity
    /// </summary>
    public interface ICarModelRepository : IClassicEntityRepository<CarModel, int>
    {
    }
}