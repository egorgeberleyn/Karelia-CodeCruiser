using System;
using System.Configuration;
using System.Linq;
using Karelia.WebAPI.Contracts.Security;

namespace Karelia.WebApiServer.Security
{
    class TokenConfigurationService : ITokenConfigurationService
    {
        const String AccessTokenExpirationKey = "AccessTokenExpiration";
        const Int32 AccessTokenDefaultExpiration = 86_400; // 24 hours

        const String RefreshTokenExpirationKey = "RefreshTokenExpiration";
        const Int32 RefreshTokenDefaultExpiration = 2_592_000; // 720 hours

        public TimeSpan AccessTokenExpiration => GetTokenExpiration(AccessTokenExpirationKey, AccessTokenDefaultExpiration);
        public TimeSpan RefreshTokenExpiration => GetTokenExpiration(RefreshTokenExpirationKey, RefreshTokenDefaultExpiration);
 
        public String GetClientId(String clientId)
        {
            if (String.IsNullOrWhiteSpace(clientId))
            {
                clientId = "Incorrectly configured client";
            }

            return clientId;
        }

        static TimeSpan GetTokenExpiration(String key, Int32 defaultExpiration)
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(key) ||
                !Int32.TryParse(ConfigurationManager.AppSettings[key], out Int32 tokenExpirationSeconds))
            {
                tokenExpirationSeconds = defaultExpiration;
            }

            TimeSpan tokenExpiration = TimeSpan.FromSeconds(tokenExpirationSeconds);

            return tokenExpiration;
        }
    }
}