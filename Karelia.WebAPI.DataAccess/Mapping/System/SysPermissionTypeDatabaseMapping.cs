using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SysPermissionType"/> to table CCSystem.PermissionTypes
    /// </summary>
    internal sealed class SysPermissionTypeDatabaseMapping : CodeBehind.CodeBehindSysPermissionTypeDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SysPermissionTypeDatabaseMapping()
        {            
        }
    }
}
