using Microsoft.AspNet.OData;
using System;
using System.Linq;
using System.Web.Http;
using BusinessFramework.WebAPI.Common.Controllers;
using BusinessFramework.WebAPI.Common.Request;
using Karelia.Contracts;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;


namespace Karelia.WebAPI.Controllers.OData
{
    /// <summary>
    ///     Controls <see cref="OfficeEquipmentModel" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class OfficeEquipmentModelController : AbstractODataController<OfficeEquipmentModel, int, IOfficeEquipmentModelRepository>
    {   
	    /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="requestInitializer"></param>     
        /// <param name="securityService"></param>     
        public OfficeEquipmentModelController(IOfficeEquipmentModelRepository repository, IRequestStorageInitializer requestInitializer, ISecurityService securityService)
		    : base(repository, requestInitializer, securityService)
		{
		    Security = securityService;
		}

		private ISecurityService Security { get; }

        /// <summary>
        /// Get all <see cref="OfficeEquipmentModel"/> objects
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IQueryable<OfficeEquipmentModel> Get()
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipmentModel_Read)){ ThrowInternalForbiddenException(@"Office equipment model.Read(OfficeEquipmentModel_Read)"); }
            return InternalGet();
        }

		/// <summary>
        /// Get <see cref="OfficeEquipmentModel"/> object by key
        /// </summary>
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IHttpActionResult Get(int key)
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipmentModel_Read)){ ThrowInternalForbiddenException(@"Office equipment model.Read(OfficeEquipmentModel_Read)"); }
            var data = Repository.GetByKey(key);
			return data == null ? (IHttpActionResult) NotFound() : Ok(data);            
        }
    }
}