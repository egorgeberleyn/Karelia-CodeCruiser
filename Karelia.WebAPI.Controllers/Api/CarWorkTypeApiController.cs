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
    ///     Controls <see cref="CarWorkType" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class CarWorkTypeApiController : AbstractApiController<CarWorkType, int, ICarWorkTypeRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public CarWorkTypeApiController(ICarWorkTypeRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="CarWorkType"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarWorkType_Read)){ return GetInternalForbiddenResult(@"Car work type.Read(CarWorkType_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="CarWorkType"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.CarWorkType_Read)){ return GetInternalForbiddenResult(@"Car work type.Read(CarWorkType_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="CarWorkType"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.CarWorkType_Create)){ return GetInternalForbiddenResult(@"Car work type.Create(CarWorkType_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarWorkType.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="CarWorkType"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.CarWorkType_Update)){ return GetInternalForbiddenResult(@"Car work type.Update(CarWorkType_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarWorkType.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="CarWorkType"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarWorkType_Delete)){ return GetInternalForbiddenResult(@"Car work type.Delete(CarWorkType_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarWorkType.Delete);
            return InternalDelete(key);
        }
    }
}
