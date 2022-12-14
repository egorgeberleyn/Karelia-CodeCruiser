using System;
using System.Collections.Generic;
using Karelia.WebAPI.Contracts.DataObjects;
using BusinessFramework.WebAPI.Contracts.Data;

namespace Karelia.WebAPI.Contracts.Repositories
{
    public interface ISysUserRepository : IClassicEntityRepository<SysUser, int>
    {
        SysUser GetByAccountNameOrEmail(string identifier);
        IList<int> GetUserPermissions(int userId);
    }
}