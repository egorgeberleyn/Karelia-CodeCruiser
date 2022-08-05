using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="CarService"/> to table dbo.CarService
    /// </summary>
    internal sealed class CarServiceDatabaseMapping : CodeBehind.CodeBehindCarServiceDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public CarServiceDatabaseMapping()
        {            
        }
    }
}
