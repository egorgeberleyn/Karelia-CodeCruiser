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
    ///     Controls <see cref="MethodicalToolkitFile" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class MethodicalToolkitFileController : AbstractODataController<MethodicalToolkitFile, int, IMethodicalToolkitFileRepository>
    {   
	    /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="requestInitializer"></param>     
        /// <param name="securityService"></param>     
        public MethodicalToolkitFileController(IMethodicalToolkitFileRepository repository, IRequestStorageInitializer requestInitializer, ISecurityService securityService)
		    : base(repository, requestInitializer, securityService)
		{
		    Security = securityService;
		}

		private ISecurityService Security { get; }

        /// <summary>
        /// Get all <see cref="MethodicalToolkitFile"/> objects
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IQueryable<MethodicalToolkitFile> Get()
        {
		    if(!Security.Authorize(DomainPermissions.MethodicalToolkitFile_Read)){ ThrowInternalForbiddenException(@"Methodical toolkit file.Read(MethodicalToolkitFile_Read)"); }
            return InternalGet();
        }

		/// <summary>
        /// Get <see cref="MethodicalToolkitFile"/> object by key
        /// </summary>
        [HttpGet]
        [EnableQuery(MaxNodeCount = DefaultOdataSettings.MaxNodeCount)]
		public IHttpActionResult Get(int key)
        {
		    if(!Security.Authorize(DomainPermissions.MethodicalToolkitFile_Read)){ ThrowInternalForbiddenException(@"Methodical toolkit file.Read(MethodicalToolkitFile_Read)"); }
            var data = Repository.GetByKey(key);
			return data == null ? (IHttpActionResult) NotFound() : Ok(data);            
        }
    }
}