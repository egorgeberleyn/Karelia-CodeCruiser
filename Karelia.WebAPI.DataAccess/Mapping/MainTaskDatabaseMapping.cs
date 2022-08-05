using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Karelia.WebAPI.Contracts.DataObjects;


namespace Karelia.WebAPI.DataAccess.Mapping
{
    /// <summary>
    /// Database mapping for <see cref="MainTask"/> to table dbo.MainTask
    /// </summary>
    internal sealed class MainTaskDatabaseMapping : CodeBehind.CodeBehindMainTaskDatabaseMapping
    {
	    /// <summary>
        /// Instance constructor
        /// </summary>
        public MainTaskDatabaseMapping()
        {            
        }
    }
}
