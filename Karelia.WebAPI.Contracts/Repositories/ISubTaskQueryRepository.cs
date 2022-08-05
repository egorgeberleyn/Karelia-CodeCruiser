using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SubTaskQuery"/> entity
    /// </summary>
    public interface ISubTaskQueryRepository : IClassicQueryRepository<SubTaskQuery, int>
    {
    }
}