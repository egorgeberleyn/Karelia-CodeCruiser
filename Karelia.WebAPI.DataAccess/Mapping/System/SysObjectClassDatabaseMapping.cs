using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SysObjectClass"/> to table CCSystem.SysObjectClasses
    /// </summary>
    internal sealed class SysObjectClassDatabaseMapping : CodeBehind.CodeBehindSysObjectClassDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SysObjectClassDatabaseMapping()
        {            
        }
    }
}
