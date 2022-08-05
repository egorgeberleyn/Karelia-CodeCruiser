﻿using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SysRole"/> entity
    /// </summary>
    public interface ISysRoleRepository : IClassicEntityRepository<SysRole, int>
    {
    }
}