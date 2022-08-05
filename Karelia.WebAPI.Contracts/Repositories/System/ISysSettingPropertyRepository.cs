using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SysSettingProperty"/> entity
    /// </summary>
    public interface ISysSettingPropertyRepository : IClassicEntityRepository<SysSettingProperty, int>
    {
    }
}