using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SysPermissionType"/> entity
    /// </summary>
    public interface ISysPermissionTypeRepository : IClassicEntityRepository<SysPermissionType, byte>
    {
    }
}