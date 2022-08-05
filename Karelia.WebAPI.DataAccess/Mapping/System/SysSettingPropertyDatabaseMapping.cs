using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SysSettingProperty"/> to table CCSystem.SettingProperties
    /// </summary>
    internal sealed class SysSettingPropertyDatabaseMapping : CodeBehind.CodeBehindSysSettingPropertyDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SysSettingPropertyDatabaseMapping()
        {            
        }
    }
}
