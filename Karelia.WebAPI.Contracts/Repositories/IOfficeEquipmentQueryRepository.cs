using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="OfficeEquipmentQuery"/> entity
    /// </summary>
    public interface IOfficeEquipmentQueryRepository : IClassicQueryRepository<OfficeEquipmentQuery, int>
    {
    }
}