using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="MethodicalToolkitFile"/> entity
    /// </summary>
    public interface IMethodicalToolkitFileRepository : IClassicEntityRepository<MethodicalToolkitFile, int>
    {
    }
}