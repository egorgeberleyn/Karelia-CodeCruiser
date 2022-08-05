using Microsoft.Owin.Security.OAuth;

namespace Karelia.WebAPI.Contracts.Security
{
    /// <summary>
    /// Bearer auth options provider
    /// </summary>
    public interface IBearerAuthenticationOptionProvider
    {
        /// <summary>
        /// Get default options
        /// </summary>
        /// <returns></returns>
        OAuthBearerAuthenticationOptions GetDefaultOptions();
    }
}
