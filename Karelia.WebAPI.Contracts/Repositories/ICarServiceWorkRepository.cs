﻿using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="CarServiceWork"/> entity
    /// </summary>
    public interface ICarServiceWorkRepository : IClassicEntityRepository<CarServiceWork, int>
    {
    }
}