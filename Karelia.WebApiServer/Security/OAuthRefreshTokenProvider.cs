using System;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Karelia.WebAPI.Contracts.Security;
using BusinessFramework.WebAPI.Security;
using BusinessFramework.WebAPI.Utils.IoC;
using Microsoft.Owin.Security.Infrastructure;

namespace Karelia.WebApiServer.Security
{
    /// <summary>
    /// Refresh token provider
    /// </summary>
    public class OAuthRefreshTokenProvider : IAuthenticationTokenProvider
    {
        private IDependencyResolver DependencyResolver { get; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="dependencyResolver"></param>
        public OAuthRefreshTokenProvider(IDependencyResolver dependencyResolver)
        {
            DependencyResolver = dependencyResolver;
        }

        /// <inheritdoc />
        public void Create(AuthenticationTokenCreateContext context)
        {
            var userIdClaim = context.Ticket.Identity.Claims.FirstOrDefault(claim => claim.Type == TokenGenerationParameters.UserIdClaim);
            string userId;
            if (userIdClaim != null)
            {
                userId = userIdClaim.Value;
            }
            else
            {
                return;
            }

            using (var scope = DependencyResolver.BeginScope())
            {
                var service = scope.Resolve<ITokenGenerationService>();
                var clientId = scope.Resolve<ITokenConfigurationService>().GetClientId(context.Ticket.Properties.Dictionary[TokenGenerationParameters.ClientIdProperty]);
                var refreshToken = service.CreateRefreshToken(userId, clientId);
                context.SetToken(refreshToken);
            }
        }

        /// <inheritdoc />
        public void Receive(AuthenticationTokenReceiveContext context)
        {
            using (var scope = DependencyResolver.BeginScope())
            {
                var service = scope.Resolve<ITokenGenerationService>();
                var ticket = service.CreateAuthenticationTicketFromRefreshToken(context.Token);
                if (ticket != null)
                {
                    //scope
                    context.SetTicket(ticket);
                }
            }
        }

        /// <inheritdoc />
        public Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            Create(context);
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            Receive(context);
            return Task.FromResult<object>(null);
        }
    }
}