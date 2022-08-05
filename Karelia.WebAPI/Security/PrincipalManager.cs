using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Principal;
using BusinessFramework.WebAPI.Contracts.Security.Hash;
using BusinessFramework.WebAPI.Contracts.Services;
using BusinessFramework.WebAPI.Security;
using ColoredConsole;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;

namespace Karelia.WebAPI.Security
{
    /// <inheritdoc />
    public sealed class PrincipalManager : IPrincipalManager
    {
        private static bool ByteArrayCompare(byte[] one, byte[] other)
        {
            if (one.Length != other.Length)
            {
                return false;
            }

            for (var i = 0; i < one.Length; i++)
            {
                if (one[i] != other[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public PrincipalManager(IPasswordHashProvider hashProvider, 
            ISysUserRepository repository, 
            IWebApiSettingsService webApiSettingsService)
        {
            Contract.Requires(repository != null);

            HashProvider = hashProvider;
            Repository = repository;
            WebApiSettingsService = webApiSettingsService;
        }

        private IPasswordHashProvider HashProvider { get; }
        private ISysUserRepository Repository { get; }
        private IWebApiSettingsService WebApiSettingsService { get; }

        /// <inheritdoc />
        public IPrincipal GetPrincipal(int? userId)
        {
            void Trace(string message)
            {
                ColorConsole.WriteLine("PrincipalManager::GetPrincipal(Int32?): ".DarkGray(), message.DarkRed());
            }

            IPrincipal principal = null;

            if (userId.HasValue)
            {
                SysUser user = Repository.GetByKey(userId.Value);
                principal  = GetPrincipal(user);
            }
            else
            {
                SysUser[] users = Repository.Set().Where(u => u.IsAnonymous).ToArray();

                switch (users.Length)
                {
                    case 0:
                        Trace("No anonymous [CCSystem].[Users] record defined");
                        break;

                    case 1:
                        principal  = GetPrincipal(users[0]);
                        break;

                    default:
                        Trace("Defined several anonymous [CCSystem].[Users] records");
                        break;
                }
            }

            return principal;
        }

        /// <inheritdoc />
        public int? Authenticate(string userName, string password, bool integratedSecurity)
        {
            var user = AuthenticateSysUser(userName, password, integratedSecurity);
            return user?.Id;
        }

        /// <inheritdoc />
        public IPrincipal AuthenticatePrincipal(string userName, string password, bool integratedSecurity)
        {
            var user = AuthenticateSysUser(userName, password, integratedSecurity);
            return GetPrincipal(user);
        }

        private IPrincipal GetPrincipal(SysUser user)
        {
            if (user == null || user.IsDeactivated)
            {
                return null;
            }

            var permissions = user.FullAccess ? null : Repository.GetUserPermissions(user.Id);
            return new SysUserPrincipal(user, permissions);
        }

        private SysUser AuthenticateSysUser(string userName, string password, bool integratedSecurity)
        {
            //TODO: Restore logging
            //Logger.LogInfo("Authenticating user " + userName + "...");

            var user = Repository.GetByAccountNameOrEmail(userName);

            if (user == null || user.IsDeactivated)
            {
                //Logger.LogInfo("User " + userName + " does not exist.");

                return null;
            }

            if (!integratedSecurity)
            {
                if (WebApiSettingsService.UseEmailVerification && !user.IsEmailConfirmed)
                {
                    return null;
                }

                var actualHash = HashProvider.GetPasswordHash(password);

                if (!ByteArrayCompare(user.PasswordHash ?? new byte[0], actualHash))
                {
                    //  Logger.LogInfo("User " + userName + " entered invalid password.");
                    return null;
                }
            }

            //Logger.LogInfo("User " + userName + " authenticated.");
            return user;
        }
    }
}