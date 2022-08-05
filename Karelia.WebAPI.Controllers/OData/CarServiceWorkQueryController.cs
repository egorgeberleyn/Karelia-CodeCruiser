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
    ///     Controls <see cref="CarServiceWorkQuery" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class CarServiceWorkQueryController : AbstractODataController<CarServiceWorkQuery, int, ICarServiceWorkQueryRepository>
    {   
	    /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="requestInitializer"></param>     
        /// <param name="securityService"></param>     
        public CarServiceWorkQueryController(ICarServiceWorkQueryRepository repository, IRequestStorageInitializer requestInitializer, ISecurityService securityService)
		    : base(repository, requestInitializer, securityService)
		{
		    Security = securityService;
		}

		private ISecurityService Security { get; }

        /// <summary>
        /// Get all <see cref="CarServiceWorkQuery"/> objects
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IQueryable<CarServiceWorkQuery> Get()
        {
		    if(!Security.Authorize(DomainPermissions.CarServiceWorkQuery_Read)){ ThrowInternalForbiddenException(@"CarServiceWorkQuery.Read(CarServiceWorkQuery_Read)"); }
            return InternalGet();
        }

		/// <summary>
        /// Get <see cref="CarServiceWorkQuery"/> object by key
        /// </summary>
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IHttpActionResult Get(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarServiceWorkQuery_Read)){ ThrowInternalForbiddenException(@"CarServiceWorkQuery.Read(CarServiceWorkQuery_Read)"); }
            var data = Repository.GetByKey(key);
			return data == null ? (IHttpActionResult) NotFound() : Ok(data);            
        }
    }
}