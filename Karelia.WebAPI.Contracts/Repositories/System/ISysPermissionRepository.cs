using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SysPermission"/> entity
    /// </summary>
    public interface ISysPermissionRepository : IClassicEntityRepository<SysPermission, int>
    {
    }
}