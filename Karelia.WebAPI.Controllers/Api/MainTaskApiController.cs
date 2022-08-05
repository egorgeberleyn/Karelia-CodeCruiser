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
    ///     Controls <see cref="MainTask" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class MainTaskApiController : AbstractApiController<MainTask, int, IMainTaskRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public MainTaskApiController(IMainTaskRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="MainTask"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.MainTask_Read)){ return GetInternalForbiddenResult(@"Main task.Read(MainTask_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="MainTask"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.MainTask_Read)){ return GetInternalForbiddenResult(@"Main task.Read(MainTask_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="MainTask"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.MainTask_Create)){ return GetInternalForbiddenResult(@"Main task.Create(MainTask_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.MainTask.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="MainTask"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.MainTask_Update)){ return GetInternalForbiddenResult(@"Main task.Update(MainTask_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.MainTask.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="MainTask"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.MainTask_Delete)){ return GetInternalForbiddenResult(@"Main task.Delete(MainTask_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.MainTask.Delete);
            return InternalDelete(key);
        }
    }
}
