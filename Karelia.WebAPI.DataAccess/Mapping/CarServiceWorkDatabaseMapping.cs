using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="CarServiceWork"/> to table dbo.CarServiceWork
    /// </summary>
    internal sealed class CarServiceWorkDatabaseMapping : CodeBehind.CodeBehindCarServiceWorkDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public CarServiceWorkDatabaseMapping()
        {            
        }
    }
}
