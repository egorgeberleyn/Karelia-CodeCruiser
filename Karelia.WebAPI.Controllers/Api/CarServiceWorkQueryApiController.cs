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
    ///     Controls <see cref="CarServiceWorkQuery" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class CarServiceWorkQueryApiController : AbstractApiController<CarServiceWorkQuery, int, ICarServiceWorkQueryRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public CarServiceWorkQueryApiController(ICarServiceWorkQueryRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="CarServiceWorkQuery"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.CarServiceWorkQuery_Read)){ return GetInternalForbiddenResult(@"CarServiceWorkQuery.Read(CarServiceWorkQuery_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="CarServiceWorkQuery"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.CarServiceWorkQuery_Read)){ return GetInternalForbiddenResult(@"CarServiceWorkQuery.Read(CarServiceWorkQuery_Read)"); }
            return InternalGetAll();
        }
    }
}
