using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="CarArrivalReasonType"/> entity
    /// </summary>
    public interface ICarArrivalReasonTypeRepository : IClassicEntityRepository<CarArrivalReasonType, int>
    {
    }
}