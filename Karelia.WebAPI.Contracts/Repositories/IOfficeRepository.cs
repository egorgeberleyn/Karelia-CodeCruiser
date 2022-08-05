﻿using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="Office"/> entity
    /// </summary>
    public interface IOfficeRepository : IClassicEntityRepository<Office, int>
    {
    }
}