using BusinessFramework.Contracts.Formatting;
using BusinessFramework.WebAPI.Common.Request;
using BusinessFramework.WebAPI.Contracts.Files;
using BusinessFramework.WebAPI.Contracts.ServerStatus;
using BusinessFramework.WebAPI.Contracts.Services;
using BusinessFramework.WebAPI.Files;
using BusinessFramework.WebAPI.ServerStatus;
using BusinessFramework.WebAPI.Services;
using FutureTechnologies.DI.Contracts;
using Karelia.WebAPI;
using Karelia.WebAPI.Contracts;

namespace Karelia.WebApiServer
{
    internal static partial class DependencyInjectionConfig
    {
        public static void Configure(IServerContainerRegistrator registrator)
        {
            registrator.Singleton<IAppSettingsService, IWebApiSettingsService, AppSettingsService>();
            registrator.Singleton<IValueFormattingService, ValueFormattingService>();
            registrator.Singleton<IWebUtilityService, WebUtilityService>();
            registrator.PerRequest<IRequestStorage, IRequestStorageInitializer, RequestStorage>();
            registrator.PerRequest<IWebApiActionService, ICurrentActionService, WebApiActionService>();
            
            ConfigureDbContext(registrator);
            ConfigureSecurity(registrator);

            registrator.PerRequest<IFilesService, FilesService>();
            ConfigureFileStorages(registrator);
            ConfigureFileStorageSaveOptions(registrator);
            ConfigureNotifiers(registrator);

            ConfigureServerContexts(registrator);
            ConfigureCustom(registrator);

            ReportingFramework.WebAPI.DependencyInjectionConfig.ConfigureSysRepositories(registrator);
            ConfigureRepositories(registrator);
            ConfigureActionServices(registrator);
            ConfigureReporting(registrator);

            // Server Status
            registrator.PerRequest<IServerStatusService, ServerStatusService>();
        }
    }
}