using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SysRolePermission"/> entity
    /// </summary>
    public interface ISysRolePermissionRepository : IClassicEntityRepository<SysRolePermission, int>
    {
    }
}