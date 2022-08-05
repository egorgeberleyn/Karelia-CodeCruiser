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
    ///     Controls <see cref="SysResetPasswordToken" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class SysResetPasswordTokenApiController : AbstractApiController<SysResetPasswordToken, int, ISysResetPasswordTokenRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public SysResetPasswordTokenApiController(ISysResetPasswordTokenRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="SysResetPasswordToken"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.SysResetPasswordToken_Read)){ return GetInternalForbiddenResult(@"Reset password token.Read(SysResetPasswordToken_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="SysResetPasswordToken"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.SysResetPasswordToken_Read)){ return GetInternalForbiddenResult(@"Reset password token.Read(SysResetPasswordToken_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="SysResetPasswordToken"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.SysResetPasswordToken_Create)){ return GetInternalForbiddenResult(@"Reset password token.Create(SysResetPasswordToken_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.SysResetPasswordToken.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="SysResetPasswordToken"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.SysResetPasswordToken_Update)){ return GetInternalForbiddenResult(@"Reset password token.Update(SysResetPasswordToken_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.SysResetPasswordToken.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="SysResetPasswordToken"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.SysResetPasswordToken_Delete)){ return GetInternalForbiddenResult(@"Reset password token.Delete(SysResetPasswordToken_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.SysResetPasswordToken.Delete);
            return InternalDelete(key);
        }
    }
}
