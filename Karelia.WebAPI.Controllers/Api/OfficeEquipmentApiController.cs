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
    ///     Controls <see cref="OfficeEquipment" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class OfficeEquipmentApiController : AbstractApiController<OfficeEquipment, int, IOfficeEquipmentRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public OfficeEquipmentApiController(IOfficeEquipmentRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="OfficeEquipment"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipment_Read)){ return GetInternalForbiddenResult(@"Office equipment.Read(OfficeEquipment_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="OfficeEquipment"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipment_Read)){ return GetInternalForbiddenResult(@"Office equipment.Read(OfficeEquipment_Read)"); }
            return InternalGetAll();
        }
        /// <summary>
        /// Create <see cref="OfficeEquipment"/> object
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipment_Create)){ return GetInternalForbiddenResult(@"Office equipment.Create(OfficeEquipment_Create)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.OfficeEquipment.Create);
            return await InternalPostAsync();
        }
        /// <summary>
        /// Update <see cref="OfficeEquipment"/> object
        /// </summary>
        public async Task<IHttpActionResult> Put()
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipment_Update)){ return GetInternalForbiddenResult(@"Office equipment.Update(OfficeEquipment_Update)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.OfficeEquipment.Update);
            return await InternalPutAsync();
        }
        /// <summary>
        /// Delete <see cref="OfficeEquipment"/> object
        /// </summary>
		public IHttpActionResult Delete(int key)
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipment_Delete)){ return GetInternalForbiddenResult(@"Office equipment.Delete(OfficeEquipment_Delete)"); }
            WebApiActionService.SetCurrentAction(DomainActions.Object.OfficeEquipment.Delete);
            return InternalDelete(key);
        }
    }
}
