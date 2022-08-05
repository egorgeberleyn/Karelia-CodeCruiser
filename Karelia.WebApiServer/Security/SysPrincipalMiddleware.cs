using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using BusinessFramework.WebAPI.Security;
using BusinessFramework.WebAPI.Utils.IoC;
using Microsoft.Owin;

namespace Karelia.WebApiServer.Security
{
    /// <summary>
    /// OWIN middleware for put authorization principal to request context
    /// </summary>
    internal sealed class SysPrincipalMiddleware : OwinMiddleware
    {
        /// <summary>
        ///     Instantiates the middleware with an optional pointer to the next component.
        /// </summary>
        /// <param name="next" />
        /// <param name="dependencyResolver"></param>
        public SysPrincipalMiddleware(OwinMiddleware next, IDependencyResolver dependencyResolver)
            : base(next)
        {
            DependencyResolver = dependencyResolver;
        }

        private IDependencyResolver DependencyResolver { get; }

        /// <summary>
        ///     Process an individual request.
        /// </summary>
        /// <param name="context" />
        /// <returns />
        public override async Task Invoke(IOwinContext context)
        {
            var claimsPrincipal = context.Authentication.User;
            var userIdClaim = claimsPrincipal?.Claims.FirstOrDefault(claim => claim.Type == TokenGenerationParameters.UserIdClaim);
            int? userId = null;

            if (userIdClaim != null)
            {
                userId = int.Parse(userIdClaim.Value);
            }
            using (var scope = DependencyResolver.BeginScope())
            {
                var principalManager = scope.Resolve<IPrincipalManager>();
                context.Request.User = principalManager.GetPrincipal(userId);
            }
            await Next.Invoke(context);
        }
    }
}