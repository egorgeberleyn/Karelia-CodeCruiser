using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SubTask"/> entity
    /// </summary>
    public interface ISubTaskRepository : IClassicEntityRepository<SubTask, int>
    {
    }
}