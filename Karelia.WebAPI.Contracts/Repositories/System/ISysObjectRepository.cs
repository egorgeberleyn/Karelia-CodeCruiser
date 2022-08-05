using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SysObject"/> entity
    /// </summary>
    public interface ISysObjectRepository : IClassicEntityRepository<SysObject, int>
    {
    }
}