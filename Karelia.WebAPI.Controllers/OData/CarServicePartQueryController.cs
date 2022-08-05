using Microsoft.AspNet.OData;
using System;
using System.Linq;
using System.Web.Http;
using BusinessFramework.WebAPI.Common.Controllers;
using BusinessFramework.WebAPI.Common.Request;
using Karelia.Contracts;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;


namespace Karelia.WebAPI.Controllers.OData
{
    /// <summary>
    ///     Controls <see cref="CarServicePartQuery" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class CarServicePartQueryController : AbstractODataController<CarServicePartQuery, int, ICarServicePartQueryRepository>
    {   
	    /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="requestInitializer"></param>     
        /// <param name="securityService"></param>     
        public CarServicePartQueryController(ICarServicePartQueryRepository repository, IRequestStorageInitializer requestInitializer, ISecurityService securityService)
		    : base(repository, requestInitializer, securityService)
		{
		    Security = securityService;
		}

		private ISecurityService Security { get; }

        /// <summary>
        /// Get all <see cref="CarServicePartQuery"/> objects
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IQueryable<CarServicePartQuery> Get()
        {
		    if(!Security.Authorize(DomainPermissions.CarServicePartQuery_Read)){ ThrowInternalForbiddenException(@"CarServicePartQuery.Read(CarServicePartQuery_Read)"); }
            return InternalGet();
        }

		/// <summary>
        /// Get <see cref="CarServicePartQuery"/> object by key
        /// </summary>
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IHttpActionResult Get(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarServicePartQuery_Read)){ ThrowInternalForbiddenException(@"CarServicePartQuery.Read(CarServicePartQuery_Read)"); }
            var data = Repository.GetByKey(key);
			return data == null ? (IHttpActionResult) NotFound() : Ok(data);            
        }
    }
}