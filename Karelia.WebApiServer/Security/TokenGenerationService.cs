using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using Karelia.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Linq;
using Karelia.WebAPI.Contracts.Security;

namespace Karelia.WebApiServer.Security
{
    static class TokenGenerationParameters
    {
        public const String UserIdClaim = "userId";
        public const String ClientIdProperty = "client_id";
    }

    sealed class TokenGenerationService : ITokenGenerationService
    {
        readonly ITokenConfigurationService _tokenConfigurationService;

        public TokenGenerationService(
            IBearerAuthenticationOptionProvider bearerAuthenticationOptionProvider,
            ISysRefreshTokenRepository sysRefreshTokenRepository,
            ITokenConfigurationService tokenConfigurationService)
        {
            _tokenConfigurationService = tokenConfigurationService;
            AuthenticationOptionProvider = bearerAuthenticationOptionProvider;
            SysRefreshTokenRepository = sysRefreshTokenRepository;
        }

        IBearerAuthenticationOptionProvider AuthenticationOptionProvider { get; }
        ISysRefreshTokenRepository SysRefreshTokenRepository { get; }

        /// <summary>
        /// Get <see cref="AuthenticationTicket"/> instance
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public AuthenticationTicket CreateAuthenticationTicket(String userId, String clientId, String user)
        {
            clientId = _tokenConfigurationService.GetClientId(clientId);
            ClaimsIdentity identity = CreateClaimIdentity(userId, user);

            AuthenticationProperties props = new AuthenticationProperties
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow + _tokenConfigurationService.AccessTokenExpiration
            };
            props.Dictionary.Add(TokenGenerationParameters.ClientIdProperty, clientId);

            return new AuthenticationTicket(identity, props);
        }

        /// <summary>
        /// Get <see cref="AuthenticationTicket"/> instance
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public AuthenticationTicket CreateAuthenticationTicketFromRefreshToken(String refreshToken)
        {
            SysRefreshToken sysRefreshToken = SysRefreshTokenRepository.Set().FirstOrDefault(t => t.Token == refreshToken);
            if (sysRefreshToken == null)
                return null;

            String user = sysRefreshToken.SysUser.AccountName;

            DateTime timedOut = DateTime.Now + TimeSpan.FromMinutes(1);

            while (true)
            {
                try
                {
                    SysRefreshTokenRepository.Delete(new SysRefreshTokenKey(sysRefreshToken.UserId, sysRefreshToken.ClientId));
                    SysRefreshTokenRepository.Save();

                    break;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (DateTime.Now > timedOut)
                        throw;
                }
            }

            return CreateAuthenticationTicket(sysRefreshToken.UserId.ToString(), sysRefreshToken.ClientId, user);
        }

        /// <summary>
        /// Create refresh token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public String CreateRefreshToken(String userId, String clientId)
        {
            String refreshToken = Guid.NewGuid().ToString();
            Int32 userIdConverted = Convert.ToInt32(userId);

            SysRefreshTokenRepository.Delete(new SysRefreshTokenKey(userIdConverted, clientId));
            SysRefreshTokenRepository.Create(new SysRefreshToken
            {
                UserId = userIdConverted,
                ClientId = clientId,
                ExpiresUtc = DateTime.UtcNow + _tokenConfigurationService.RefreshTokenExpiration,
                Token = refreshToken
            });
            SysRefreshTokenRepository.Save();

            return refreshToken;
        }

        /// <summary>
        /// Get token response
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public JObject GenerateTokenResponse(String userId, String clientId, String user)
        {
            AuthenticationTicket ticket = CreateAuthenticationTicket(userId, clientId, user);
            String accessToken = AuthenticationOptionProvider.GetDefaultOptions().AccessTokenFormat.Protect(ticket);
            String refreshToken = CreateRefreshToken(userId, clientId);

            JObject tokenResponse = new JObject(
                new JProperty("access_token", accessToken),
                new JProperty("token_type", "bearer"),
                new JProperty("refresh_token", refreshToken),
                new JProperty("user", user)
            );

            return tokenResponse;
        }

        static ClaimsIdentity CreateClaimIdentity(String userId, String name)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new []
                {
                    new Claim(TokenGenerationParameters.UserIdClaim, userId),
                    new Claim(ClaimTypes.Name, name)
                },
                OAuthDefaults.AuthenticationType);

            return identity;
        }
    }
}

