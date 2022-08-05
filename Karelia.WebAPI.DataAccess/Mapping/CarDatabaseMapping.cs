using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="Car"/> to table dbo.Car
    /// </summary>
    internal sealed class CarDatabaseMapping : CodeBehind.CodeBehindCarDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public CarDatabaseMapping()
        {            
        }
    }
}
