using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SysObjectType"/> entity
    /// </summary>
    public interface ISysObjectTypeRepository : IClassicEntityRepository<SysObjectType, int>
    {
    }
}