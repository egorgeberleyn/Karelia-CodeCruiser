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
    ///     Controls <see cref="CarModel" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class CarModelApiController : AbstractApiController<CarModel, int, ICarModelRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public CarModelApiController(ICarModelRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="CarModel"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarModel_Read)){ return GetInternalForbiddenResult(@"Car model.Read(CarModel_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="CarModel"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.CarModel_Read)){ return GetInternalForbiddenResult(@"Car model.Read(CarModel_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="CarModel"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.CarModel_Create)){ return GetInternalForbiddenResult(@"Car model.Create(CarModel_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarModel.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="CarModel"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.CarModel_Update)){ return GetInternalForbiddenResult(@"Car model.Update(CarModel_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarModel.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="CarModel"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarModel_Delete)){ return GetInternalForbiddenResult(@"Car model.Delete(CarModel_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarModel.Delete);
            return InternalDelete(key);
        }
    }
}
