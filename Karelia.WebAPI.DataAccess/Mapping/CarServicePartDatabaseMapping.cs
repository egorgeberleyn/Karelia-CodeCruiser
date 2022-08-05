using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="CarServicePart"/> to table dbo.CarServicePart
    /// </summary>
    internal sealed class CarServicePartDatabaseMapping : CodeBehind.CodeBehindCarServicePartDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public CarServicePartDatabaseMapping()
        {            
        }
    }
}
