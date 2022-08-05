using System;
using System.Configuration;
using System.IO;
using System.Linq;
using FutureTechnologies.DI.Contracts;
using ReportingFramework.Central.Aspose.Cells;
using ReportingFramework.Central.Contracts.Engine;
using ReportingFramework.Central.Contracts.Spreadsheet.Engine;
using ReportingFramework.WebAPI.DataSources;
using Karelia.WebAPI.Contracts.Reporting;
using Karelia.WebAPI.Reporting;

namespace Karelia.WebApiServer
{
    internal static partial class DependencyInjectionConfig
    {
        private static readonly string TempRootFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + "_Reports");

        private static void ConfigureReporting(IServerContainerRegistrator registrator)
        {
            registrator.Singleton<IEngineSwitcher<SpreadsheetEngine>, EngineSwitcher<SpreadsheetEngine>>(
                new Parameter("defaultEngineName", AsposeSpreadsheetEngine.Name),
                new Parameter("factories", GetSpreadsheetEngineFactories));
            registrator.Singleton<IEngineFactory<SpreadsheetEngine>, AsposeSpreadsheetEngineFactory>(AsposeSpreadsheetEngine.Name);

            registrator.Singleton<IReportingService, ReportingService>(
                new Parameter("reportsDirectory", GetAppSettingValue("ServerReportsDirectory")),
                new Parameter("cacheDirectory", GetCacheDirectory()));

            registrator.PerRequest<IReportDataExtractor, ReportDataExtractor>();
            registrator.PerRequest<IReportingDataSourceManager, ReportingDataSourceManager>();
            
        }
        private static string GetCacheDirectory()
        {
            var appSetting = GetAppSettingValue("ServerReportsCacheDirectory");
            return !string.IsNullOrEmpty(appSetting) ? appSetting : Path.Combine(TempRootFolder, "Cache");
        }


        public static string GetAppSettingValue(string settingName)
        {
            string result = null;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(settingName))
            {
                result = ConfigurationManager.AppSettings[settingName];
            }
            return result;
        }

        private static IEngineFactory<SpreadsheetEngine>[] GetSpreadsheetEngineFactories(IScope scope)
        {
            return scope.ResolveAll<IEngineFactory<SpreadsheetEngine>>().ToArray();
        }
    }
}
