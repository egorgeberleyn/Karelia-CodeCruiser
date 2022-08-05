using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SysUsersDisplayView"/> entity
    /// </summary>
    public interface ISysUsersDisplayViewRepository : IClassicEntityRepository<SysUsersDisplayView, int>
    {
    }
}