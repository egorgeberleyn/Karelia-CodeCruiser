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
    ///     Controls <see cref="MethodicalToolkit" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class MethodicalToolkitApiController : AbstractApiController<MethodicalToolkit, int, IMethodicalToolkitRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public MethodicalToolkitApiController(IMethodicalToolkitRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="MethodicalToolkit"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.MethodicalToolkit_Read)){ return GetInternalForbiddenResult(@"Methodical toolkit.Read(MethodicalToolkit_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="MethodicalToolkit"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.MethodicalToolkit_Read)){ return GetInternalForbiddenResult(@"Methodical toolkit.Read(MethodicalToolkit_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="MethodicalToolkit"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.MethodicalToolkit_Create)){ return GetInternalForbiddenResult(@"Methodical toolkit.Create(MethodicalToolkit_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.MethodicalToolkit.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="MethodicalToolkit"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.MethodicalToolkit_Update)){ return GetInternalForbiddenResult(@"Methodical toolkit.Update(MethodicalToolkit_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.MethodicalToolkit.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="MethodicalToolkit"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.MethodicalToolkit_Delete)){ return GetInternalForbiddenResult(@"Methodical toolkit.Delete(MethodicalToolkit_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.MethodicalToolkit.Delete);
            return InternalDelete(key);
        }
    }
}
