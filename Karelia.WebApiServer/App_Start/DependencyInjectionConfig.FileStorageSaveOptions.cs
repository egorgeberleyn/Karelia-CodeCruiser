using BusinessFramework.WebAPI.Contracts.Files.Storage;
using FutureTechnologies.DI.Contracts;
using Karelia.WebAPI.File;


namespace Karelia.WebApiServer
{
    internal static partial class DependencyInjectionConfig
    {
        public static void ConfigureFileStorageSaveOptions(IServerContainerRegistrator registrator)
        {
		    registrator.PerRequest<IFileStorageSaveOptionsSwitcher, FileStorageSaveOptionsSwitcher>();            
        }
    }
}