using System;
using System.Data.Entity;
using System.Linq;
using BusinessFramework.Contracts;
using BusinessFramework.WebAPI.Common.Data;
using BusinessFramework.WebAPI.Contracts.Data;
using Karelia.Contracts.DataObjects;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;


namespace Karelia.WebAPI.DataAccess.Repositories.CodeBehind
{
    /// <summary>
    /// Repository for <see cref="CodeBehindOfficeEquipmentModelRepository"/> objects
    /// </summary>
    public abstract class CodeBehindOfficeEquipmentModelRepository : ClassicEntityRepository<OfficeEquipmentModel, int, IApiDbContext>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected CodeBehindOfficeEquipmentModelRepository(IApiDbContext context) 
		    :base(context)
        {

        }


    
    }
}