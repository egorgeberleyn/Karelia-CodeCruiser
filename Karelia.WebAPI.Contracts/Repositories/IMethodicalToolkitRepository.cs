using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="MethodicalToolkit"/> entity
    /// </summary>
    public interface IMethodicalToolkitRepository : IClassicEntityRepository<MethodicalToolkit, int>
    {
    }
}