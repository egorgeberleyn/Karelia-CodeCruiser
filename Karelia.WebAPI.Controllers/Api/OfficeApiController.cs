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
    ///     Controls <see cref="Office" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class OfficeApiController : AbstractApiController<Office, int, IOfficeRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public OfficeApiController(IOfficeRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="Office"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.Office_Read)){ return GetInternalForbiddenResult(@"Office.Read(Office_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="Office"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.Office_Read)){ return GetInternalForbiddenResult(@"Office.Read(Office_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="Office"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.Office_Create)){ return GetInternalForbiddenResult(@"Office.Create(Office_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.Office.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="Office"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.Office_Update)){ return GetInternalForbiddenResult(@"Office.Update(Office_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.Office.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="Office"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.Office_Delete)){ return GetInternalForbiddenResult(@"Office.Delete(Office_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.Office.Delete);
            return InternalDelete(key);
        }
    }
}
