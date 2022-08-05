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
    ///     Controls <see cref="CarServicePart" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class CarServicePartApiController : AbstractApiController<CarServicePart, int, ICarServicePartRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public CarServicePartApiController(ICarServicePartRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="CarServicePart"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarServicePart_Read)){ return GetInternalForbiddenResult(@"Car service part.Read(CarServicePart_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="CarServicePart"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.CarServicePart_Read)){ return GetInternalForbiddenResult(@"Car service part.Read(CarServicePart_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="CarServicePart"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.CarServicePart_Create)){ return GetInternalForbiddenResult(@"Car service part.Create(CarServicePart_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarServicePart.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="CarServicePart"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.CarServicePart_Update)){ return GetInternalForbiddenResult(@"Car service part.Update(CarServicePart_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarServicePart.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="CarServicePart"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarServicePart_Delete)){ return GetInternalForbiddenResult(@"Car service part.Delete(CarServicePart_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarServicePart.Delete);
            return InternalDelete(key);
        }
    }
}
