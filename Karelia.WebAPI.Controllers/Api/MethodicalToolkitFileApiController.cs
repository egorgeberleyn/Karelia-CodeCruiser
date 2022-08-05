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
    ///     Controls <see cref="MethodicalToolkitFile" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class MethodicalToolkitFileApiController : AbstractApiController<MethodicalToolkitFile, int, IMethodicalToolkitFileRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public MethodicalToolkitFileApiController(IMethodicalToolkitFileRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="MethodicalToolkitFile"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.MethodicalToolkitFile_Read)){ return GetInternalForbiddenResult(@"Methodical toolkit file.Read(MethodicalToolkitFile_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="MethodicalToolkitFile"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.MethodicalToolkitFile_Read)){ return GetInternalForbiddenResult(@"Methodical toolkit file.Read(MethodicalToolkitFile_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="MethodicalToolkitFile"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.MethodicalToolkitFile_Create)){ return GetInternalForbiddenResult(@"Methodical toolkit file.Create(MethodicalToolkitFile_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.MethodicalToolkitFile.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="MethodicalToolkitFile"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.MethodicalToolkitFile_Update)){ return GetInternalForbiddenResult(@"Methodical toolkit file.Update(MethodicalToolkitFile_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.MethodicalToolkitFile.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="MethodicalToolkitFile"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.MethodicalToolkitFile_Delete)){ return GetInternalForbiddenResult(@"Methodical toolkit file.Delete(MethodicalToolkitFile_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.MethodicalToolkitFile.Delete);
            return InternalDelete(key);
        }
    }
}
