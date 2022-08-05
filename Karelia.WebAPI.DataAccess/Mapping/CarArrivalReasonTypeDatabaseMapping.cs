using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="CarArrivalReasonType"/> to table dbo.CarArrivalReasonType
    /// </summary>
    internal sealed class CarArrivalReasonTypeDatabaseMapping : CodeBehind.CodeBehindCarArrivalReasonTypeDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public CarArrivalReasonTypeDatabaseMapping()
        {            
        }
    }
}
