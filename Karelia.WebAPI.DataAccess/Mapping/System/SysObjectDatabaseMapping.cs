using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SysObject"/> to table CCSystem.SysObjects
    /// </summary>
    internal sealed class SysObjectDatabaseMapping : CodeBehind.CodeBehindSysObjectDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SysObjectDatabaseMapping()
        {            
        }
    }
}
