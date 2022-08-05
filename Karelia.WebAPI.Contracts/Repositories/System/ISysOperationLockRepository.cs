using System;
using System.Collections.Generic;
using Karelia.WebAPI.Contracts.DataObjects;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    public interface ISysOperationLockRepository : IEntityRepository<SysOperationLock, SysOperationLockKey>
    {
        void Cleanup();
    }
}