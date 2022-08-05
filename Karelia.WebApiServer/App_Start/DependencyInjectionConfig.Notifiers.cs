using BusinessFramework.WebAPI.Common.Notifiers;
using BusinessFramework.WebAPI.Common.Notifiers.Factories;
using BusinessFramework.WebAPI.Contracts.Notifiers;
using FutureTechnologies.DI.Contracts;

namespace Karelia.WebApiServer
{
    internal static partial class DependencyInjectionConfig
    {
        private static void ConfigureNotifiers(IServerContainerRegistrator registrator)
        {
            registrator.Singleton<INotifierFactory, EmailNotifierFactory>("Email");
            registrator.Singleton<INotifierFactory, SmsNotifierFactory>("Sms");

            registrator.Singleton<INotifierManager, NotifierManager>();
        }
    }
}