using BusinessFramework.WebAPI.Contracts.Services;

namespace Karelia.WebAPI.Contracts
{
    public interface IAppSettingsService: IWebApiSettingsService
    {
        /// <summary>
        /// Server instance name
        /// </summary>
        string InstanceName { get; }
    }
}