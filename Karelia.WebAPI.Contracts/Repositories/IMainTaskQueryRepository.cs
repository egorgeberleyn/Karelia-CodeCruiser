using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="MainTaskQuery"/> entity
    /// </summary>
    public interface IMainTaskQueryRepository : IClassicQueryRepository<MainTaskQuery, int>
    {
    }
}