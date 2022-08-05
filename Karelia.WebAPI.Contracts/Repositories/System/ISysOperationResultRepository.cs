using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.Contracts.Enums;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SysOperationResult"/> entity
    /// </summary>
    public interface ISysOperationResultRepository : IClassicEntityRepository<SysOperationResult, byte>
    {
    }
}