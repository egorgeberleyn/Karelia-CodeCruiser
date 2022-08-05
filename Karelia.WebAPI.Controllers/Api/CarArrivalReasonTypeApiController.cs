using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BusinessFramework.WebAPI.Common.Controllers;
using BusinessFramework.WebAPI.Common.Request;
using BusinessFramework.WebAPI.Common.Security;
using BusinessFramework.WebAPI.Contracts.Data;
using BusinessFramework.WebAPI.Contracts.Files.Storage;
using BusinessFramework.WebAPI.Contracts.Services;
using BusinessFramework.WebAPI.Contracts.Validation;
using Karelia.Contracts;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;


namespace Karelia.WebAPI.Controllers.Api
{
    /// <summary>
    ///     Controls <see cref="CarArrivalReasonType" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class CarArrivalReasonTypeApiController : AbstractApiController<CarArrivalReasonType, int, ICarArrivalReasonTypeRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public CarArrivalReasonTypeApiController(ICarArrivalReasonTypeRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="CarArrivalReasonType"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarArrivalReasonType_Read)){ return GetInternalForbiddenResult(@"Car arrival reason type.Read(CarArrivalReasonType_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="CarArrivalReasonType"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.CarArrivalReasonType_Read)){ return GetInternalForbiddenResult(@"Car arrival reason type.Read(CarArrivalReasonType_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="CarArrivalReasonType"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.CarArrivalReasonType_Create)){ return GetInternalForbiddenResult(@"Car arrival reason type.Create(CarArrivalReasonType_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarArrivalReasonType.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="CarArrivalReasonType"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.CarArrivalReasonType_Update)){ return GetInternalForbiddenResult(@"Car arrival reason type.Update(CarArrivalReasonType_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarArrivalReasonType.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="CarArrivalReasonType"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarArrivalReasonType_Delete)){ return GetInternalForbiddenResult(@"Car arrival reason type.Delete(CarArrivalReasonType_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarArrivalReasonType.Delete);
            return InternalDelete(key);
        }
    }
}
