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
    /// Repository for <see cref="CodeBehindSysUserPermissionsDisplayViewRepository"/> objects
    /// </summary>
    public abstract class CodeBehindSysUserPermissionsDisplayViewRepository : EntityRepository<SysUserPermissionsDisplayView, SysUserPermissionsDisplayViewKey, IApiDbContext>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected CodeBehindSysUserPermissionsDisplayViewRepository(IApiDbContext context) 
		    :base(context)
        {

        }



        /// <inheritdoc />
        public override SysUserPermissionsDisplayView GetByKey(SysUserPermissionsDisplayViewKey key)
        {
            return Set().FirstOrDefault(entity => entity.UserId == key.UserId && entity.PermissionId == key.PermissionId);
        }
    
    }
}