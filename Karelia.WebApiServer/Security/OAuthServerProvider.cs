using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using BusinessFramework.WebAPI.Security;
using BusinessFramework.WebAPI.Utils.IoC;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Karelia.WebApiServer.Properties;
using Karelia.WebAPI.Contracts.Security;

namespace Karelia.WebApiServer.Security
{
    /// <summary>
    /// OAuth server provider
    /// </summary>
    sealed class OAuthServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// Creates new instance of default provider behavior
        /// </summary>
        public OAuthServerProvider(IDependencyResolver dependencyResolver)
        {
            DependencyResolver = dependencyResolver;
        }

        IDependencyResolver DependencyResolver { get; }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // OAuth2 supports the notion of client authentication
            // this is not used here

            context.TryGetFormCredentials(out _, out _);

            return Task.FromResult(context.Validated());
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (IDependencyScope scope = DependencyResolver.BeginScope())
            {
                IPrincipalManager principalManager = scope.Resolve<IPrincipalManager>();
                Int32? userId = principalManager.Authenticate(context.UserName, context.Password, false);

                if (!userId.HasValue)
                {
                    context.SetError(CommonResources.AuthenticationFailed);
                    return Task.FromResult(false);
                }

                AuthenticationTicket authenticationTicket = scope.Resolve<ITokenGenerationService>().CreateAuthenticationTicket(
                    userId.ToString(), 
                    scope.Resolve<ITokenConfigurationService>().GetClientId(context.ClientId), 
                    context.UserName);

                return Task.FromResult(context.Validated(authenticationTicket));
            }
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            String originalClient = context.Ticket.Properties.Dictionary[TokenGenerationParameters.ClientIdProperty] ?? String.Empty;
            String currentClient = DependencyResolver.Resolve<ITokenConfigurationService>().GetClientId(context.ClientId);

            // enforce client binding of refresh token
            if (originalClient != currentClient)
            {
                context.Rejected();
                return Task.FromResult(false);
            }

            // chance to change authentication ticket for refresh token requests
            ClaimsIdentity newId = new ClaimsIdentity(context.Ticket.Identity);
            AuthenticationTicket newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
            return Task.FromResult(context.Validated(newTicket));
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            context.AdditionalResponseParameters.Add("user", context.Identity.Name);

            return base.TokenEndpointResponse(context);
        }
    }
}