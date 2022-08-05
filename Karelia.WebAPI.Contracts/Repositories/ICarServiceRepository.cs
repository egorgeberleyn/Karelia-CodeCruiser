using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="CarService"/> entity
    /// </summary>
    public interface ICarServiceRepository : IClassicEntityRepository<CarService, int>
    {
    }
}