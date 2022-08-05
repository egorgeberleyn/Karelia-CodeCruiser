using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="OfiiceEmployee"/> entity
    /// </summary>
    public interface IOfiiceEmployeeRepository : IClassicEntityRepository<OfiiceEmployee, int>
    {
    }
}