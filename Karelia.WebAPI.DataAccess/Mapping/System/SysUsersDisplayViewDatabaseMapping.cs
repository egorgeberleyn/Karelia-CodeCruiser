using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SysUsersDisplayView"/> to table CCSystem.UsersDisplayView
    /// </summary>
    internal sealed class SysUsersDisplayViewDatabaseMapping : CodeBehind.CodeBehindSysUsersDisplayViewDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SysUsersDisplayViewDatabaseMapping()
        {            
        }
    }
}
