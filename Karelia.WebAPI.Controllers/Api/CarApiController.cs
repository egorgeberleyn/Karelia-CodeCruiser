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
    ///     Controls <see cref="Car" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class CarApiController : AbstractApiController<Car, int, ICarRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public CarApiController(ICarRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="Car"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.Car_Read)){ return GetInternalForbiddenResult(@"Car.Read(Car_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="Car"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.Car_Read)){ return GetInternalForbiddenResult(@"Car.Read(Car_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="Car"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.Car_Create)){ return GetInternalForbiddenResult(@"Car.Create(Car_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.Car.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="Car"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.Car_Update)){ return GetInternalForbiddenResult(@"Car.Update(Car_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.Car.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="Car"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.Car_Delete)){ return GetInternalForbiddenResult(@"Car.Delete(Car_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.Car.Delete);
            return InternalDelete(key);
        }
    }
}
