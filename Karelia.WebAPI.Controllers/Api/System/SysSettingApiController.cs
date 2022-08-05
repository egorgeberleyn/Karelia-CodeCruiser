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
    ///     Controls <see cref="SysSetting" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class SysSettingApiController : AbstractApiController<SysSetting, int, ISysSettingRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public SysSettingApiController(ISysSettingRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="SysSetting"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.Settings)){ return GetInternalForbiddenResult(@"Settings(Settings)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="SysSetting"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.Settings)){ return GetInternalForbiddenResult(@"Settings(Settings)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="SysSetting"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.Settings)){ return GetInternalForbiddenResult(@"Settings(Settings)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.SysSetting.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="SysSetting"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.Settings)){ return GetInternalForbiddenResult(@"Settings(Settings)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.SysSetting.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="SysSetting"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.Settings)){ return GetInternalForbiddenResult(@"Settings(Settings)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.SysSetting.Delete);
            return InternalDelete(key);
        }
    }
}
