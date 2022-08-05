using Microsoft.AspNet.OData;
using System;
using System.Linq;
using System.Web.Http;
using BusinessFramework.WebAPI.Common.Controllers;
using BusinessFramework.WebAPI.Common.Request;
using Karelia.Contracts;
using Karelia.Contracts.DataObjects;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;


namespace Karelia.WebAPI.Controllers.OData
{
    /// <summary>
    ///     Controls <see cref="SysOperationLock" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class SysOperationLockController : AbstractODataController<SysOperationLock, SysOperationLockKey, ISysOperationLockRepository>
    {   
	    /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="requestInitializer"></param>     
        /// <param name="securityService"></param>     
        public SysOperationLockController(ISysOperationLockRepository repository, IRequestStorageInitializer requestInitializer, ISecurityService securityService)
		    : base(repository, requestInitializer, securityService)
		{
		    Security = securityService;
		}

		private ISecurityService Security { get; }

        /// <summary>
        /// Get all <see cref="SysOperationLock"/> objects
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IQueryable<SysOperationLock> Get()
        {
		    if(!Security.Authorize(DomainPermissions.OperationLock)){ ThrowInternalForbiddenException(@"Operation lock management(OperationLock)"); }
            return InternalGet();
        }

		/// <summary>
        /// Get <see cref="SysOperationLock"/> object by key
        /// </summary>
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IHttpActionResult Get(SysOperationLockKey key)
        {
		    if(!Security.Authorize(DomainPermissions.OperationLock)){ ThrowInternalForbiddenException(@"Operation lock management(OperationLock)"); }
            var data = Repository.GetByKey(key);
			return data == null ? (IHttpActionResult) NotFound() : Ok(data);            
        }
    }
}