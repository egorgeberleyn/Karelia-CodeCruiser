using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="OfficeEquipmentModel"/> entity
    /// </summary>
    public interface IOfficeEquipmentModelRepository : IClassicEntityRepository<OfficeEquipmentModel, int>
    {
    }
}