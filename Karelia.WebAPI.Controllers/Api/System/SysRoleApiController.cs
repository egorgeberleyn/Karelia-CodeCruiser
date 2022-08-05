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
    ///     Controls <see cref="SysRole" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class SysRoleApiController : AbstractApiController<SysRole, int, ISysRoleRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public SysRoleApiController(ISysRoleRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="SysRole"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.SysRole_Read)){ return GetInternalForbiddenResult(@"Role.Read(SysRole_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="SysRole"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.SysRole_Read)){ return GetInternalForbiddenResult(@"Role.Read(SysRole_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="SysRole"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.SysRole_Create)){ return GetInternalForbiddenResult(@"Role.Create(SysRole_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.SysRole.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="SysRole"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.SysRole_Update)){ return GetInternalForbiddenResult(@"Role.Update(SysRole_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.SysRole.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="SysRole"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.SysRole_Delete)){ return GetInternalForbiddenResult(@"Role.Delete(SysRole_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.SysRole.Delete);
            return InternalDelete(key);
        }
    }
}
