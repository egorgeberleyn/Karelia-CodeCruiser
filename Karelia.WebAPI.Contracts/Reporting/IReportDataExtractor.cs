using System.Collections;
using System.Collections.Generic;
using ReportingFramework.Central.Contracts.Data;

namespace Karelia.WebAPI.Contracts.Reporting
{
    /// <summary>
    /// Service for extract data for the reporting
    /// </summary>
    public interface IReportDataExtractor
    {
        /// <summary>
        /// Get data from single <see cref="IEnumerable"/>
        /// </summary>
        /// <param name="name">Name of data set</param>
        /// <param name="data">Collection with data objects</param>
        /// <returns>Source for report</returns>
        SourceCollection GetData(string name, IEnumerable data);
        /// <summary>
        /// Get data from some <see cref="IEnumerable"/> sources
        /// </summary>
        /// <param name="data">Collection of pairs name of source / data</param>
        /// <returns>Source for report</returns>
        SourceCollection GetData(Dictionary<string, IEnumerable> data);
        /// <summary>
        /// Get data from storage procedure
        /// </summary>
        /// <param name="procedureName">Name of procedure</param>
        /// <param name="parameters">Parameters of procedure</param>
        /// <returns></returns>
        SourceCollection GetData(string procedureName, Dictionary<string, object> parameters = null);
    }
}