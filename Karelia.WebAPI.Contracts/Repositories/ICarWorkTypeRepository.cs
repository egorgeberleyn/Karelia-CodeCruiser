using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="CarWorkType"/> entity
    /// </summary>
    public interface ICarWorkTypeRepository : IClassicEntityRepository<CarWorkType, int>
    {
    }
}