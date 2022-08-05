using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using BusinessFramework.WebAPI.Contracts.Owin;
using BusinessFramework.WebAPI.Security;
using BusinessFramework.WebAPI.Utils.IoC;

namespace Karelia.WebApiServer.Security
{
    class BasicAuthenticationProvider : IBasicAuthenticationProvider
    {
        readonly IDependencyResolver _dependencyResolver;

        public BasicAuthenticationProvider(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        public Task<ClaimsIdentity> Athenticate(String userName, String password)
        {
            using (IDependencyScope scope = _dependencyResolver.BeginScope())
            {
                Int32? userId = scope.Resolve<IPrincipalManager>().Authenticate(userName, password, false);
                if (userId == null)
                    return Task.FromResult<ClaimsIdentity>(null);

                ClaimsIdentity identity = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(TokenGenerationParameters.UserIdClaim, userId.Value.ToString()),
                        new Claim(ClaimTypes.Name, userName)
                    },
                    BasicAuthenticationDefaults.AuthenticationType);

                return Task.FromResult(identity);
            }
        }
    }
}