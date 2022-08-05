using BusinessFramework.Contracts.Security.Hash;
using BusinessFramework.WebAPI.Contracts.Owin;
using BusinessFramework.WebAPI.Security;
using BusinessFramework.WebAPI.Contracts.Security;
using BusinessFramework.WebAPI.Contracts.Security.Hash;
using FutureTechnologies.DI.Contracts;
using Karelia.WebApiServer.Security;
using Karelia.WebAPI;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.Security;
using Karelia.WebAPI.Security;
using Microsoft.Owin.Security.OAuth;

namespace Karelia.WebApiServer
{
    internal static partial class DependencyInjectionConfig
    {
        private static void ConfigureSecurity(IServerContainerRegistrator registrator)
        {
            registrator.Singleton<IHashProvider, DefaultHashProvider>();
            registrator.Singleton<IPasswordHashProvider, PasswordHashProvider>();
            registrator.Singleton<IBasicAuthenticationProvider, BasicAuthenticationProvider>();
            registrator.Singleton<IOAuthBearerAuthenticationProvider, BearerAuthenticationProvider>();
            registrator.Singleton<IBearerAuthenticationOptionProvider, BearerAuthenticationOptionProvider>();
            registrator.Singleton<ITokenConfigurationService, TokenConfigurationService>();

            registrator.PerRequest<IPrincipalManager, PrincipalManager>();
            registrator.PerRequest<IEmailConfirmationService, EmailConfirmationService>();
            registrator.PerRequest<ISecurityService, ICommonSecurityService, SecurityService>();
            registrator.PerRequest<ITokenGenerationService, TokenGenerationService>();
            registrator.PerRequest<IPostRegistrationActionService, PostRegistrationActionService>();
            registrator.PerRequest<ISysUserService, SysUserService>();
        }
    }
}