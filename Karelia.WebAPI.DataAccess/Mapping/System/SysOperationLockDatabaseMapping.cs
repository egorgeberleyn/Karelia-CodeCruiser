using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SysOperationLock"/> to table CCSystem.OperationLocks
    /// </summary>
    internal sealed class SysOperationLockDatabaseMapping : CodeBehind.CodeBehindSysOperationLockDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SysOperationLockDatabaseMapping()
        {            
        }
    }
}
