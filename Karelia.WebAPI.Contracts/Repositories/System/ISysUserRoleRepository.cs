using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SysUserRole"/> entity
    /// </summary>
    public interface ISysUserRoleRepository : IClassicEntityRepository<SysUserRole, int>
    {
    }
}