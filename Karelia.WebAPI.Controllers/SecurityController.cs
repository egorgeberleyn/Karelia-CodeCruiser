using System.Web.Http;
using BusinessFramework.Contracts.Security;
using BusinessFramework.WebAPI.Common.Controllers;
using BusinessFramework.WebAPI.Common.Request;
using Karelia.Contracts;
using Karelia.WebAPI.Contracts;

namespace Karelia.WebApi.Controllers
{
    /// <summary>
    ///     Controls public security context
    /// </summary>
    public sealed class SecurityController : AbstractApiController
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public SecurityController(ISecurityService securityService, IRequestStorageInitializer requestInitializer)
            : base(requestInitializer, securityService)
        {
            SecurityService = securityService;
        }

        private ISecurityService SecurityService { get; set; }

        /// <summary>
        /// Get public security context
        /// </summary>
        /// <returns></returns>
        public PublicSecurityContext<PublicDomainPermissions> Post()
        {
            return SecurityService.GetPublicContext();
        }
    }
}