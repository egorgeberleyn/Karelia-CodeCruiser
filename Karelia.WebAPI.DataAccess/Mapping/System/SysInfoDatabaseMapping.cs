using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SysInfo"/> to table CCSystem.Info
    /// </summary>
    internal sealed class SysInfoDatabaseMapping : CodeBehind.CodeBehindSysInfoDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SysInfoDatabaseMapping()
        {            
        }
    }
}
