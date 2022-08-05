using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="Car"/> entity
    /// </summary>
    public interface ICarRepository : IClassicEntityRepository<Car, int>
    {
    }
}