using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace Karelia.WebApiServer.Security
{
    class BearerAuthenticationProvider : IOAuthBearerAuthenticationProvider
    {
        public const String ClientIdProperty = "client_id";

        public Task RequestToken(OAuthRequestTokenContext context)
        {
            return Task.FromResult<Object>(null);
        }

        public Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            context.OwinContext.Environment[ClientIdProperty] = context.Ticket.Properties.Dictionary[ClientIdProperty];

            return Task.FromResult<Object>(null);
        }

        public Task ApplyChallenge(OAuthChallengeContext context)
        {
            return Task.FromResult<Object>(null);
        }
    }
}