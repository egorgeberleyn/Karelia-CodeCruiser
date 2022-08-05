using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SysPermission"/> to table CCSystem.Permissions
    /// </summary>
    internal sealed class SysPermissionDatabaseMapping : CodeBehind.CodeBehindSysPermissionDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SysPermissionDatabaseMapping()
        {            
        }
    }
}
