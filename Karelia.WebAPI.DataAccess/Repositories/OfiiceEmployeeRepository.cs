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
    /// Repository for <see cref="OfiiceEmployeeRepository"/> objects
    /// </summary>
    public sealed class OfiiceEmployeeRepository : CodeBehind.CodeBehindOfiiceEmployeeRepository, IOfiiceEmployeeRepository
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public OfiiceEmployeeRepository(
            //--  custom dependencies
            //-- /custom dependencies
            IApiDbContext context) 
		    : base(context)
        {
        }
    }
}