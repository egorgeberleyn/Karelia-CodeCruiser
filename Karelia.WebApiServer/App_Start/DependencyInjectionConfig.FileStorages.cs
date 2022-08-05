using BusinessFramework.WebAPI.Common.Files.Storages;
using BusinessFramework.WebAPI.Common.Files.Storages.Factories;
using BusinessFramework.WebAPI.Contracts.Files.Storage;
using FutureTechnologies.DI;
using FutureTechnologies.DI.Contracts;


namespace Karelia.WebApiServer
{
    static partial class DependencyInjectionConfig
    {
        class FileStorageDependencyInjectionConfig : AbstractManagedExtensionConfigurator<IFileStorageFactoryRegistrator>
        {
            public FileStorageDependencyInjectionConfig(IContainerRegistrator containerRegistrator) 
            	: base("bin", "BusinessFramework.WebAPI.Common*", containerRegistrator) 
            {
            }

            protected override void Configure(IFileStorageFactoryRegistrator fileStorageFactoryRegistrator)
            {
                fileStorageFactoryRegistrator.Singleton(ContainerRegistrator);
            }
        }

        static void ConfigureFileStorages(IServerContainerRegistrator registrator)
        {
            using (FileStorageDependencyInjectionConfig fileStorageDependencyInjectionConfig = new FileStorageDependencyInjectionConfig(registrator))
            {
                fileStorageDependencyInjectionConfig.Configure();
            }

            registrator.PerRequest<IFileStorageSwitcher, FileStorageSwitcher>(new Parameter("defaultStorage", ""));
        }
	}
}