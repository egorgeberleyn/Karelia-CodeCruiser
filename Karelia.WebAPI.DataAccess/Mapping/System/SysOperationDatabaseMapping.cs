using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SysOperation"/> to table CCSystem.Operation
    /// </summary>
    internal sealed class SysOperationDatabaseMapping : CodeBehind.CodeBehindSysOperationDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SysOperationDatabaseMapping()
        {            
        }
    }
}
