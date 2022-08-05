using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Dependencies;
using BusinessFramework.Contracts;
using System.Web.Http.ExceptionHandling;
using BusinessFramework.WebAPI.Contracts.Owin;
using BusinessFramework.WebAPI.Owin;
using BusinessFramework.WebAPI.Utils.IoC;
using FutureTechnologies.DI.Contracts;
using FutureTechnologies.DI.UnityContainer;
//using DalSoft.WebApi.HelpPage; //Uncomment for api help page
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Karelia.WebApiServer;
using Karelia.WebApiServer.Middlewares;
using Karelia.WebApiServer.Security;
using Microsoft.Owin.Logging;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.Security;
using IOwinLogger = Microsoft.Owin.Logging.ILogger;
using ILogger = BusinessFramework.Contracts.ILogger;


[assembly: OwinStartup(typeof(Startup))]

namespace Karelia.WebApiServer
{
    /// <summary>
    /// Api server startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Api server configuration
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            var owinLogger = app.CreateLogger("serverTrace");
            owinLogger.WriteInformation("======================= Service is starting =======================");

            var dependencyResolver = GetDependencyResolver(owinLogger);
            var logger = dependencyResolver.Resolve<ILogger>();

            logger.Info("Configuring service...");

            //NOTE: Cors must be the first
            app.UseCors(CorsOptions.AllowAll);

            app.Use<LoggingMiddleware>(logger);
            app.Use<LocalizationMiddleware>();
#if DEBUG
            app.Use<TraceMiddleware>();
#endif

            // Basic authetication
            if (Boolean.TryParse(ConfigurationManager.AppSettings["EnableBasicAuthentication"], out Boolean enableBasicAuthentication) &&
               enableBasicAuthentication)
            {
                app.UseBasicAuthentication(new BasicAuthenticationOptions
                {
                    Provider = new BasicAuthenticationProvider(dependencyResolver)
                });
            }

            // token generation
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = DependencyExtensions.Resolve<ITokenConfigurationService>(dependencyResolver).AccessTokenExpiration,
                Provider = new OAuthServerProvider(dependencyResolver),
                RefreshTokenProvider = new OAuthRefreshTokenProvider(dependencyResolver)
            });

            var bearerOptionProvider = dependencyResolver.Resolve<IBearerAuthenticationOptionProvider>();

            // token consumption
            app.UseOAuthBearerAuthentication(bearerOptionProvider.GetDefaultOptions());

            app.Use<SysPrincipalMiddleware>(dependencyResolver);



            var configuration = GetHttpConfiguration(dependencyResolver);
            configuration.Services.Replace(typeof(IExceptionLogger), new AppExceptionLogger(logger));

            app.UseWebApi(configuration);

			//TODO: Uncomment for enable api help. Doesn't support OData
            //app.UseWebApiHelpPage(configuration, "api_help");
            logger.Info("Configuration completed.");
        }

        private static IDependencyResolver GetDependencyResolver(IOwinLogger logger)
        {
            logger.WriteInformation("Configuring dependencies...");

            var registrator = new UnityContainerRegistrator();

            registrator.Singleton<ILogger, OwinLogger>(new Parameter("owinLog", logger));
            DependencyInjectionConfig.Configure(registrator);

            var dependencyResolver = registrator.ToResolver();
            registrator.Instance(dependencyResolver);
            return new DependencyResolver(dependencyResolver);
        }

        private static HttpConfiguration GetHttpConfiguration(IDependencyResolver dependencyResolver)
        {
            var configuration = new HttpConfiguration { DependencyResolver = dependencyResolver };

            HttpConfig.Configure(configuration);

            configuration.MapHttpAttributeRoutes();

            ODataConfig.Configure(configuration);

            WebApiConfig.Configure(configuration);

            return configuration;
        }
    }
}