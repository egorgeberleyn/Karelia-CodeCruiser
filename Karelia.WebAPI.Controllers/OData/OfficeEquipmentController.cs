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
    ///     Controls <see cref="OfficeEquipment" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class OfficeEquipmentController : AbstractODataController<OfficeEquipment, int, IOfficeEquipmentRepository>
    {   
	    /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="requestInitializer"></param>     
        /// <param name="securityService"></param>     
        public OfficeEquipmentController(IOfficeEquipmentRepository repository, IRequestStorageInitializer requestInitializer, ISecurityService securityService)
		    : base(repository, requestInitializer, securityService)
		{
		    Security = securityService;
		}

		private ISecurityService Security { get; }

        /// <summary>
        /// Get all <see cref="OfficeEquipment"/> objects
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IQueryable<OfficeEquipment> Get()
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipment_Read)){ ThrowInternalForbiddenException(@"Office equipment.Read(OfficeEquipment_Read)"); }
            return InternalGet();
        }

		/// <summary>
        /// Get <see cref="OfficeEquipment"/> object by key
        /// </summary>
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IHttpActionResult Get(int key)
        {
		    if(!Security.Authorize(DomainPermissions.OfficeEquipment_Read)){ ThrowInternalForbiddenException(@"Office equipment.Read(OfficeEquipment_Read)"); }
            var data = Repository.GetByKey(key);
			return data == null ? (IHttpActionResult) NotFound() : Ok(data);            
        }
    }
}