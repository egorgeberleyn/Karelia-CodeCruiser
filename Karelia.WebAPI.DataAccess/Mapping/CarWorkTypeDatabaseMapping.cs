using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="CarWorkType"/> to table dbo.CarWorkType
    /// </summary>
    internal sealed class CarWorkTypeDatabaseMapping : CodeBehind.CodeBehindCarWorkTypeDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public CarWorkTypeDatabaseMapping()
        {            
        }
    }
}
