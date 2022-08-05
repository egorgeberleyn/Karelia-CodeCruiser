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
    ///     Controls <see cref="MainTaskQuery" /> objects
    /// </summary>
    [AllowAnonymous]
	public sealed class MainTaskQueryApiController : AbstractApiController<MainTaskQuery, int, IMainTaskQueryRepository>
    {
	    /// <summary>
        /// Ctor
        /// </summary>
        public MainTaskQueryApiController(IMainTaskQueryRepository repository, IEntityValidatorFactory validatorFactory, IRequestStorageInitializer requestInitializer, 
		                               ISecurityService securityService, IWebApiActionService webApiActionService)
            : base(repository, validatorFactory, requestInitializer, securityService)
        {
            WebApiActionService = webApiActionService;
			Security = securityService;
        }

        private IWebApiActionService WebApiActionService { get; }

		private ISecurityService Security { get; }


		/// <summary>
        /// Get <see cref="MainTaskQuery"/> object by key
        /// </summary>          
        public IHttpActionResult GetByKey(int key)
        {
		    if(!Security.Authorize(DomainPermissions.MainTaskQuery_Read)){ return GetInternalForbiddenResult(@"Основные Задачи.Read(MainTaskQuery_Read)"); }
            return InternalGetByKey(key);
        }

        /// <summary>
        /// Get all <see cref="MainTaskQuery"/> objects
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
		    if(!Security.Authorize(DomainPermissions.MainTaskQuery_Read)){ return GetInternalForbiddenResult(@"Основные Задачи.Read(MainTaskQuery_Read)"); }
            return InternalGetAll();
        }
    }
}
