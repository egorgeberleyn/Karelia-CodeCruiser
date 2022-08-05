using System;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.DataObjects;

namespace Karelia.WebAPI.Contracts.Repositories
{
    /// <summary>
    /// Repository for  <see cref="SysRefreshToken"/> entity
    /// </summary>
    public interface ISysRefreshTokenRepository : IEntityRepository<SysRefreshToken, SysRefreshTokenKey>
    {
    }
}