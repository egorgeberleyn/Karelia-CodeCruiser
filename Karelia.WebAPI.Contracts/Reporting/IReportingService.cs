using BusinessFramework.Contracts.Reporting;
using ReportingFramework.Central.Contracts.Data;
using ReportingFramework.Central.Contracts.Reports;

namespace Karelia.WebAPI.Contracts.Reporting
{
    /// <summary>
    /// Report generation service
    /// </summary>
    public interface IReportingService
    {
        /// <summary>
        /// Generate report
        /// </summary>
        Report GetReport(string reportName, SourceCollection data, ReportFormat format, string fileName = null);
    }
}