using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SysOperationResult"/> to table CCSystem.OperationResult
    /// </summary>
    internal sealed class SysOperationResultDatabaseMapping : CodeBehind.CodeBehindSysOperationResultDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SysOperationResultDatabaseMapping()
        {            
        }
    }
}
