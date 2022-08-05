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
    ///     Controls <see cref="OfficeEquipmentModel" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class OfficeEquipmentModelApiController : AbstractApiController<OfficeEquipmentModel, int, IOfficeEquipmentModelRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public OfficeEquipmentModelApiController(IOfficeEquipmentModelRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="OfficeEquipmentModel"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipmentModel_Read)){ return GetInternalForbiddenResult(@"Office equipment model.Read(OfficeEquipmentModel_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="OfficeEquipmentModel"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipmentModel_Read)){ return GetInternalForbiddenResult(@"Office equipment model.Read(OfficeEquipmentModel_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="OfficeEquipmentModel"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipmentModel_Create)){ return GetInternalForbiddenResult(@"Office equipment model.Create(OfficeEquipmentModel_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.OfficeEquipmentModel.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="OfficeEquipmentModel"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipmentModel_Update)){ return GetInternalForbiddenResult(@"Office equipment model.Update(OfficeEquipmentModel_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.OfficeEquipmentModel.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="OfficeEquipmentModel"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipmentModel_Delete)){ return GetInternalForbiddenResult(@"Office equipment model.Delete(OfficeEquipmentModel_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.OfficeEquipmentModel.Delete);
            return InternalDelete(key);
        }
    }
}
