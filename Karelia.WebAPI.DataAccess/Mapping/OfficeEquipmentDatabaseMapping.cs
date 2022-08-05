using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="OfficeEquipment"/> to table dbo.OfficeEquipment
    /// </summary>
    internal sealed class OfficeEquipmentDatabaseMapping : CodeBehind.CodeBehindOfficeEquipmentDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public OfficeEquipmentDatabaseMapping()
        {            
        }
    }
}
