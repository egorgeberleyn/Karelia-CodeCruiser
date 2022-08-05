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
    ///     Controls <see cref="CarModelPart" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class CarModelPartApiController : AbstractApiController<CarModelPart, int, ICarModelPartRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public CarModelPartApiController(ICarModelPartRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="CarModelPart"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarModelPart_Read)){ return GetInternalForbiddenResult(@"Car model part.Read(CarModelPart_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="CarModelPart"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.CarModelPart_Read)){ return GetInternalForbiddenResult(@"Car model part.Read(CarModelPart_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="CarModelPart"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.CarModelPart_Create)){ return GetInternalForbiddenResult(@"Car model part.Create(CarModelPart_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarModelPart.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="CarModelPart"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.CarModelPart_Update)){ return GetInternalForbiddenResult(@"Car model part.Update(CarModelPart_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarModelPart.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="CarModelPart"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarModelPart_Delete)){ return GetInternalForbiddenResult(@"Car model part.Delete(CarModelPart_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarModelPart.Delete);
            return InternalDelete(key);
        }
    }
}
