using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="SubTask"/> to table dbo.SubTask
    /// </summary>
    internal sealed class SubTaskDatabaseMapping : CodeBehind.CodeBehindSubTaskDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public SubTaskDatabaseMapping()
        {            
        }
    }
}
