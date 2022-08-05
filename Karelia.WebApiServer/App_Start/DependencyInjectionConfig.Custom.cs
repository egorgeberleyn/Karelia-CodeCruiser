using BusinessFramework.WebAPI.Contracts.Validation;
using BusinessFramework.WebAPI.Validation;
using FutureTechnologies.DI.Contracts;

namespace Karelia.WebApiServer
{
    internal static partial class DependencyInjectionConfig
    {
        private static void ConfigureCustom(IServerContainerRegistrator registrator)
        {
			//NOTE: Temp validator registration
            registrator.PerRequest<IEntityValidatorFactory, EmptyEntityValidatorFactory>();
        }
    }
}