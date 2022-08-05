using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SysRole"/> to table CCSystem.Roles
    /// </summary>
    internal sealed class SysRoleDatabaseMapping : CodeBehind.CodeBehindSysRoleDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SysRoleDatabaseMapping()
        {            
        }
    }
}
