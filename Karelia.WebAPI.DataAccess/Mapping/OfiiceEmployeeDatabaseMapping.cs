using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="OfiiceEmployee"/> to table dbo.OfiiceEmployee
    /// </summary>
    internal sealed class OfiiceEmployeeDatabaseMapping : CodeBehind.CodeBehindOfiiceEmployeeDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public OfiiceEmployeeDatabaseMapping()
        {            
        }
    }
}
