using System;
using System.Data.Entity.SqlServer;
using System.Linq;
using BusinessFramework.WebAPI.Common.Data;
using BusinessFramework.WebAPI.Contracts.Files;
using Karelia.Contracts;
using Karelia.Contracts.Enums;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;


namespace Karelia.WebAPI.DataAccess.Repositories
{
    /// <summary>
    /// Repository for <see cref="MethodicalToolkitRepository"/> objects
    /// </summary>
    public sealed class MethodicalToolkitRepository : CodeBehind.CodeBehindMethodicalToolkitRepository, IMethodicalToolkitRepository
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public MethodicalToolkitRepository(
            //--  custom dependencies
            //-- /custom dependencies
            IApiDbContext context) 
		    : base(context)
        {
        }
    }
}