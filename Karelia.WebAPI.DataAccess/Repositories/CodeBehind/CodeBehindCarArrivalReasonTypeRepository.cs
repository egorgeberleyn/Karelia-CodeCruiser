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
    /// Repository for <see cref="CodeBehindCarArrivalReasonTypeRepository"/> objects
    /// </summary>
    public abstract class CodeBehindCarArrivalReasonTypeRepository : ClassicEntityRepository<CarArrivalReasonType, int, IApiDbContext>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected CodeBehindCarArrivalReasonTypeRepository(IApiDbContext context) 
		    :base(context)
        {

        }


    
    }
}