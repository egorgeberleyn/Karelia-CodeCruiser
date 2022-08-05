﻿using System;
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
    /// Repository for <see cref="CarServicePartQueryRepository"/> objects
    /// </summary>
    public sealed class CarServicePartQueryRepository : CodeBehind.CodeBehindCarServicePartQueryRepository, ICarServicePartQueryRepository
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public CarServicePartQueryRepository(
            //--  custom dependencies
            //-- /custom dependencies
            IApiDbContext context) 
		    : base(context)
        {
        }
    
    }
}