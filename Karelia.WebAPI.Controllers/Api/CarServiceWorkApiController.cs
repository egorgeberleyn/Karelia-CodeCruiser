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
    ///     Controls <see cref="CarServiceWork" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class CarServiceWorkApiController : AbstractApiController<CarServiceWork, int, ICarServiceWorkRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public CarServiceWorkApiController(ICarServiceWorkRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="CarServiceWork"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarServiceWork_Read)){ return GetInternalForbiddenResult(@"Car service work.Read(CarServiceWork_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="CarServiceWork"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.CarServiceWork_Read)){ return GetInternalForbiddenResult(@"Car service work.Read(CarServiceWork_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="CarServiceWork"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.CarServiceWork_Create)){ return GetInternalForbiddenResult(@"Car service work.Create(CarServiceWork_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarServiceWork.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="CarServiceWork"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.CarServiceWork_Update)){ return GetInternalForbiddenResult(@"Car service work.Update(CarServiceWork_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarServiceWork.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="CarServiceWork"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarServiceWork_Delete)){ return GetInternalForbiddenResult(@"Car service work.Delete(CarServiceWork_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarServiceWork.Delete);
            return InternalDelete(key);
        }
    }
}
