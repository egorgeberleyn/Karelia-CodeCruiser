using System.Data.SqlClient;
using System.Linq;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.Repositories;

namespace Karelia.WebAPI.DataAccess.Repositories
{
    /// <summary>
    /// Repository for <see cref="SysSettingRepository"/> objects
    /// </summary>
    public sealed class SysSettingRepository : CodeBehind.CodeBehindSysSettingRepository, ISysSettingRepository
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public SysSettingRepository(
            //--  custom dependencies
            //-- /custom dependencies
            IApiDbContext context) 
		    : base(context)
        {
        }

        /// <inheritdoc />
        public string GetGlobalPropertyValue(string propertyName)
        {
            var value = Context.SqlQuery<string>(@"
SELECT [Value]
FROM [CCSystem].[Settings]
WHERE [SettingPropertyId] = (SELECT Id FROM [CCSystem].[SettingProperties] WHERE Name = @PropertyName)
	AND [UserId] IS NULL",
                    new SqlParameter("@PropertyName", propertyName))
                .FirstOrDefault();
            return value;
        }
    }
}