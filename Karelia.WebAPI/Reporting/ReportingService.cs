using System.IO;
using BusinessFramework.Contracts.Reporting;
using BusinessFramework.Contracts.Utils.Processing;
using BusinessFramework.Utils.EvaluationEngine.Evaluate;
using ReportingFramework.Central;
using ReportingFramework.Central.Contracts.Data;
using ReportingFramework.Central.Contracts.Engine;
using ReportingFramework.Central.Contracts.Reports;
using ReportingFramework.Central.Contracts.Spreadsheet.Engine;
using ReportingFramework.Central.Spreadsheet;
using Karelia.WebAPI.Contracts.Reporting;

namespace Karelia.WebAPI.Reporting
{
    /// <inheritdoc />
    public sealed class ReportingService : IReportingService
    {
        private readonly string _reportsDirectory;
        private readonly DirectoryInfo _cacheDirectory;
        private readonly IReportManagerFactory _managerFactory;

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public ReportingService(string reportsDirectory, string cacheDirectory, IEngineSwitcher<SpreadsheetEngine> engineSwitcher)
        {
            _reportsDirectory = reportsDirectory;
            _managerFactory = new SpreadsheetReportManagerFactory(engineSwitcher, StandardFunctionEvaluationContext.Instance);
            _cacheDirectory = new DirectoryInfo(cacheDirectory);
        }

        private StreamReport CreateReport(string reportName, SourceCollection data, ReportFormat format)
        {
            var reportTemplate = Path.Combine(_reportsDirectory, reportName) + ".xlsx";
            using (var manager = _managerFactory.Create(_cacheDirectory))
            {
                ICallBack callBack = null;
                CallBack.InitCallBack(ref callBack);
                return manager.CreateReport(callBack, reportTemplate, data, format);
            }
        }

        /// <inheritdoc />
        public Report GetReport(string reportName, SourceCollection data, ReportFormat format, string fileName = null)
        {
            var streamReport = CreateReport(reportName, data, format);
            return new Report(fileName, streamReport.ReportExtension, streamReport.GetStream());
        }
    }
}