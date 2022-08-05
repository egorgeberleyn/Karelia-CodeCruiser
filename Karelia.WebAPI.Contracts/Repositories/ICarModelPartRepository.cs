using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="CarModelPart"/> entity
    /// </summary>
    public interface ICarModelPartRepository : IClassicEntityRepository<CarModelPart, int>
    {
    }
}