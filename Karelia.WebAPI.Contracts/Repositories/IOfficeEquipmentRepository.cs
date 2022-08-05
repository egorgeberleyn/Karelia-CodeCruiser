using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="OfficeEquipment"/> entity
    /// </summary>
    public interface IOfficeEquipmentRepository : IClassicEntityRepository<OfficeEquipment, int>
    {
    }
}