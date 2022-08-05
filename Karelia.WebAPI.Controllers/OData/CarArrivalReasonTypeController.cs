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
    ///     Controls <see cref="CarArrivalReasonType" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class CarArrivalReasonTypeController : AbstractODataController<CarArrivalReasonType, int, ICarArrivalReasonTypeRepository>
    {   
	    /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="requestInitializer"></param>     
        /// <param name="securityService"></param>     
        public CarArrivalReasonTypeController(ICarArrivalReasonTypeRepository repository, IRequestStorageInitializer requestInitializer, ISecurityService securityService)
		    : base(repository, requestInitializer, securityService)
		{
		    Security = securityService;
		}

		private ISecurityService Security { get; }

        /// <summary>
        /// Get all <see cref="CarArrivalReasonType"/> objects
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IQueryable<CarArrivalReasonType> Get()
        {
		    if(!Security.Authorize(DomainPermissions.CarArrivalReasonType_Read)){ ThrowInternalForbiddenException(@"Car arrival reason type.Read(CarArrivalReasonType_Read)"); }
            return InternalGet();
        }

		/// <summary>
        /// Get <see cref="CarArrivalReasonType"/> object by key
        /// </summary>
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IHttpActionResult Get(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarArrivalReasonType_Read)){ ThrowInternalForbiddenException(@"Car arrival reason type.Read(CarArrivalReasonType_Read)"); }
            var data = Repository.GetByKey(key);
			return data == null ? (IHttpActionResult) NotFound() : Ok(data);            
        }
    }
}