using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SysObjectClass"/> entity
    /// </summary>
    public interface ISysObjectClassRepository : IClassicEntityRepository<SysObjectClass, byte>
    {
    }
}