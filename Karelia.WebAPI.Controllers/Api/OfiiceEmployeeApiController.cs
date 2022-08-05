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
    ///     Controls <see cref="OfiiceEmployee" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class OfiiceEmployeeApiController : AbstractApiController<OfiiceEmployee, int, IOfiiceEmployeeRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public OfiiceEmployeeApiController(IOfiiceEmployeeRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="OfiiceEmployee"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.OfiiceEmployee_Read)){ return GetInternalForbiddenResult(@"OfficeEmployee.Read(OfiiceEmployee_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="OfiiceEmployee"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.OfiiceEmployee_Read)){ return GetInternalForbiddenResult(@"OfficeEmployee.Read(OfiiceEmployee_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="OfiiceEmployee"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.OfiiceEmployee_Create)){ return GetInternalForbiddenResult(@"OfficeEmployee.Create(OfiiceEmployee_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.OfiiceEmployee.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="OfiiceEmployee"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.OfiiceEmployee_Update)){ return GetInternalForbiddenResult(@"OfficeEmployee.Update(OfiiceEmployee_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.OfiiceEmployee.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="OfiiceEmployee"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.OfiiceEmployee_Delete)){ return GetInternalForbiddenResult(@"OfficeEmployee.Delete(OfiiceEmployee_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.OfiiceEmployee.Delete);
            return InternalDelete(key);
        }
    }
}
