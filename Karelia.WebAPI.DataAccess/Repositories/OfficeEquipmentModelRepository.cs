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
    /// Repository for <see cref="OfficeEquipmentModelRepository"/> objects
    /// </summary>
    public sealed class OfficeEquipmentModelRepository : CodeBehind.CodeBehindOfficeEquipmentModelRepository, IOfficeEquipmentModelRepository
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public OfficeEquipmentModelRepository(
            //--  custom dependencies
            //-- /custom dependencies
            IApiDbContext context) 
		    : base(context)
        {
        }
    }
}