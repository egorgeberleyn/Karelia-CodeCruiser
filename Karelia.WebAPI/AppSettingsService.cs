using System.Configuration;
using BusinessFramework.Contracts.Services;
using BusinessFramework.WebAPI.Services;
using Karelia.WebAPI.Contracts;

namespace Karelia.WebAPI
{
    /// <summary>
    /// App settings service
    /// </summary>
    public sealed class AppSettingsService : WebApiSettingsService, IAppSettingsService
    {
        /// <summary>
        /// Server instance name
        /// </summary>
        public string InstanceName
        {
            get
            {
                return GetValue("InstanceName");
            }
        }
    }
}