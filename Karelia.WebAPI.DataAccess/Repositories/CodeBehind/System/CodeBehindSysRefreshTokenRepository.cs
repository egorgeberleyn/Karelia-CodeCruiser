using System;
using System.Data.Entity;
using System.Linq;
using BusinessFramework.Contracts;
using BusinessFramework.WebAPI.Common.Data;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.Contracts.DataObjects;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;


namespace Karelia.WebAPI.DataAccess.Repositories.CodeBehind
{
    /// <summary>
    /// Repository for <see cref="CodeBehindSysRefreshTokenRepository"/> objects
    /// </summary>
    public abstract class CodeBehindSysRefreshTokenRepository : EntityRepository<SysRefreshToken, SysRefreshTokenKey, IApiDbContext>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected CodeBehindSysRefreshTokenRepository(IApiDbContext context) 
		    :base(context)
        {

        }



        /// <inheritdoc />
        public override SysRefreshToken GetByKey(SysRefreshTokenKey key)
        {
            return Set().FirstOrDefault(entity => entity.UserId == key.UserId && entity.ClientId == key.ClientId);
        }
    
    }
}