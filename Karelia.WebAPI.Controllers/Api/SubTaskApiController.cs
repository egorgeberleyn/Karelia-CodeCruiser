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
    ///     Controls <see cref="SubTask" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class SubTaskApiController : AbstractApiController<SubTask, int, ISubTaskRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public SubTaskApiController(ISubTaskRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="SubTask"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.SubTask_Read)){ return GetInternalForbiddenResult(@"Sub task.Read(SubTask_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="SubTask"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.SubTask_Read)){ return GetInternalForbiddenResult(@"Sub task.Read(SubTask_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="SubTask"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.SubTask_Create)){ return GetInternalForbiddenResult(@"Sub task.Create(SubTask_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.SubTask.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="SubTask"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.SubTask_Update)){ return GetInternalForbiddenResult(@"Sub task.Update(SubTask_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.SubTask.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="SubTask"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.SubTask_Delete)){ return GetInternalForbiddenResult(@"Sub task.Delete(SubTask_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.SubTask.Delete);
            return InternalDelete(key);
        }
    }
}
