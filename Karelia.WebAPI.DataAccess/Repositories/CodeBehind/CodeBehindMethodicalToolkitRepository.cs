﻿using System;
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
    /// Repository for <see cref="CodeBehindMethodicalToolkitRepository"/> objects
    /// </summary>
    public abstract class CodeBehindMethodicalToolkitRepository : ClassicEntityRepository<MethodicalToolkit, int, IApiDbContext>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        protected CodeBehindMethodicalToolkitRepository(IApiDbContext context) 
		    :base(context)
        {

        }


    
    }
}