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
    ///     Controls <see cref="OfficeEquipmentQuery" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class OfficeEquipmentQueryApiController : AbstractApiController<OfficeEquipmentQuery, int, IOfficeEquipmentQueryRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public OfficeEquipmentQueryApiController(IOfficeEquipmentQueryRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="OfficeEquipmentQuery"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipmentQuery_Read)){ return GetInternalForbiddenResult(@"OfficeEquipmentQuery.Read(OfficeEquipmentQuery_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="OfficeEquipmentQuery"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipmentQuery_Read)){ return GetInternalForbiddenResult(@"OfficeEquipmentQuery.Read(OfficeEquipmentQuery_Read)"); }
            return InternalGetAll();
        }
    }
}
