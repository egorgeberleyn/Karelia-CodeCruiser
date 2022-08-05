using Microsoft.Owin.Security.OAuth;
using Karelia.WebAPI.Contracts.Security;

namespace Karelia.WebApiServer.Security
{
    /// <inheritdoc />
    public class BearerAuthenticationOptionProvider : IBearerAuthenticationOptionProvider
    {
        readonly OAuthBearerAuthenticationOptions _defaultOptions = new OAuthBearerAuthenticationOptions();

        /// <inheritdoc />
        public BearerAuthenticationOptionProvider(IOAuthBearerAuthenticationProvider bearerAuthenticationProvider)
        {
            _defaultOptions.Provider = bearerAuthenticationProvider;
        }

        /// <inheritdoc />
        public OAuthBearerAuthenticationOptions GetDefaultOptions()
        {
            return _defaultOptions;
        }
    }
}