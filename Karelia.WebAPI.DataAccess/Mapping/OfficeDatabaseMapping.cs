using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="Office"/> to table dbo.Office
    /// </summary>
    internal sealed class OfficeDatabaseMapping : CodeBehind.CodeBehindOfficeDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public OfficeDatabaseMapping()
        {            
        }
    }
}
