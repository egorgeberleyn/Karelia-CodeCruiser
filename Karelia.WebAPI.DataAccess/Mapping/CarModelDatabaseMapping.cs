using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="CarModel"/> to table dbo.CarModel
    /// </summary>
    internal sealed class CarModelDatabaseMapping : CodeBehind.CodeBehindCarModelDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public CarModelDatabaseMapping()
        {            
        }
    }
}
