using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SysObjectType"/> to table CCSystem.ObjectTypes
    /// </summary>
    internal sealed class SysObjectTypeDatabaseMapping : CodeBehind.CodeBehindSysObjectTypeDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SysObjectTypeDatabaseMapping()
        {            
        }
    }
}
