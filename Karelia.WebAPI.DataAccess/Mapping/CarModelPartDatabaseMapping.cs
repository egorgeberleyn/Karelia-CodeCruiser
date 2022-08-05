using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="CarModelPart"/> to table dbo.CarModelPart
    /// </summary>
    internal sealed class CarModelPartDatabaseMapping : CodeBehind.CodeBehindCarModelPartDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public CarModelPartDatabaseMapping()
        {            
        }
    }
}
