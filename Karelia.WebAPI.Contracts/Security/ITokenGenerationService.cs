using System;
using Microsoft.Owin.Security;
using Newtonsoft.Json.Linq;

namespace Karelia.WebAPI.Contracts.Security
{
    /// <summary>
    /// Service for generate access token by user name
    /// </summary>
    public interface ITokenGenerationService
    {
        /// <summary>
        /// Get <see cref="AuthenticationTicket"/> instance
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        AuthenticationTicket CreateAuthenticationTicket(String userId, String clientId, String user);

        /// <summary>
        /// Get <see cref="AuthenticationTicket"/> instance
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        AuthenticationTicket CreateAuthenticationTicketFromRefreshToken(String refreshToken);

        /// <summary>
        /// Create refresh token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        String CreateRefreshToken(String userId, String clientId);

        /// <summary>
        /// Get token response
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        JObject GenerateTokenResponse(String userId, String clientId, String user);
    }
}