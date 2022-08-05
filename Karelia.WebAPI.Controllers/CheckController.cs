using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using BusinessFramework.Contracts;
using BusinessFramework.WebAPI.Common.Controllers;
using BusinessFramework.WebAPI.Common.Request;
using BusinessFramework.WebAPI.Contracts.Security;
using BusinessFramework.WebAPI.Contracts.ServerStatus;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;


namespace Karelia.WebAPI.Controllers
{
    /// <summary>
    ///     Check connection and get version of server
    /// </summary>
    [AllowAnonymous]
    public class CheckController : AbstractApiController
    {
        readonly IAppSettingsService _appSettingsService;
        readonly ISysInfoRepository _sysInfoRepository;
        readonly IServerStatusService _serverStatusService;

        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="appSettingsService"></param>
        /// <param name="securityService"></param>
        /// <param name="sysInfoRepository"></param>
        /// <param name="serverStatusService"></param>
        public CheckController(IRequestStorageInitializer requestInitializer, IAppSettingsService appSettingsService, ICommonSecurityService securityService, ISysInfoRepository sysInfoRepository, IServerStatusService serverStatusService)
            : base(requestInitializer, securityService)
        {
            _appSettingsService = appSettingsService;
            _sysInfoRepository = sysInfoRepository;
            _serverStatusService = serverStatusService;
        }

        /// <summary>
        ///     Get server version
        /// </summary>
        /// <returns></returns>
        public ServerMetadata Get()
        {
            return new ServerMetadata
            {
                Version = Assembly.GetExecutingAssembly().GetName().Version,
                InstanceName = _appSettingsService.InstanceName
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public Object Get([FromUri(Name = "id")] String domain)
        {
            switch (domain)
            {
                case "connections":
                    return _serverStatusService.Connections();

                case "scripts":
                    SysInfo sysInfo = _sysInfoRepository.Set().First();
                    return _serverStatusService.Scripts(new Version("1.0.0.17"), new DateTime(2022, 7, 22, 11, 14, 27), () => (new Version(sysInfo.SystemVersion), sysInfo.LastInitialization));

                case "filestorages":
                    return _serverStatusService.FileStorages();

                case "reports":
                    return _serverStatusService.Reports();

                default:
                    return Get();
            }
        }
    }
}