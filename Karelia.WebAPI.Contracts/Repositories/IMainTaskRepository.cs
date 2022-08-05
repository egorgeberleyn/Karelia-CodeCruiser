using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="MainTask"/> entity
    /// </summary>
    public interface IMainTaskRepository : IClassicEntityRepository<MainTask, int>
    {
    }
}