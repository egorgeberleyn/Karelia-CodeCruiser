﻿using System.Linq;
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
    ///     Controls <see cref="CarService" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class CarServiceApiController : AbstractApiController<CarService, int, ICarServiceRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public CarServiceApiController(ICarServiceRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="CarService"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarService_Read)){ return GetInternalForbiddenResult(@"Car service.Read(CarService_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="CarService"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.CarService_Read)){ return GetInternalForbiddenResult(@"Car service.Read(CarService_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="CarService"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.CarService_Create)){ return GetInternalForbiddenResult(@"Car service.Create(CarService_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarService.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="CarService"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.CarService_Update)){ return GetInternalForbiddenResult(@"Car service.Update(CarService_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarService.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="CarService"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarService_Delete)){ return GetInternalForbiddenResult(@"Car service.Delete(CarService_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.CarService.Delete);
            return InternalDelete(key);
        }
    }
}
