using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="CarServicePart"/> entity
    /// </summary>
    public interface ICarServicePartRepository : IClassicEntityRepository<CarServicePart, int>
    {
    }
}