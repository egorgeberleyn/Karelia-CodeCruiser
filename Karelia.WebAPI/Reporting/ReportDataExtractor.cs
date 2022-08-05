using System.Collections;
using System.Collections.Generic;
using System.Data;
using ReportingFramework.Central.Contracts.Data;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Contracts.Reporting;


namespace Karelia.WebAPI.Reporting
{
    /// <inheritdoc />
    public sealed class ReportDataExtractor: IReportDataExtractor
    {
        private readonly IApiDbContext _apiDbContext;

        /// <summary>
        /// Ctor
        /// </summary>
        public ReportDataExtractor(IApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        private DataTable[] ExecuteStoredProcedure(string procedureName, Dictionary<string, object> parameters)
        {
            using (var connection = _apiDbContext.Connection)
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = procedureName;
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            var dbParameter = command.CreateParameter();
                            dbParameter.Value = parameter.Value;
                            dbParameter.ParameterName = parameter.Key;
                            command.Parameters.Add(dbParameter);
                        }
                    }
                    try
                    {
                        connection.Open();
                        var dataTables = new List<DataTable>();
                        IDataReader reader = command.ExecuteReader();
                        do
                        {
                            AddDataTable(dataTables, reader);
                        } while (!reader.IsClosed);
                        connection.Close();
                        return dataTables.ToArray();
                    }
                    catch
                    {
                    }
                }
            }
            return new DataTable[0];
        }
        private void AddDataTable(ICollection<DataTable> tables, IDataReader dataReader)
        {
            var table = new DataTable();
            table.Load(dataReader);
            table.TableName = string.Format("Data{0}", tables.Count + 1);
            tables.Add(table);
        }

        /// <summary>
        /// Get data from storage procedure
        /// </summary>
        /// <param name="procedureName">Name of procedure</param>
        /// <param name="parameters">Parameters of procedure</param>
        /// <returns></returns>
        public SourceCollection GetData(string procedureName, Dictionary<string, object> parameters = null)
        {
            return ExecuteStoredProcedure(procedureName, parameters).ToSourceCollection();
        }
        /// <summary>
        /// Get data from single <see cref="IEnumerable"/>
        /// </summary>
        /// <param name="name">Name of data set</param>
        /// <param name="data">Collection with data objects</param>
        /// <returns>Source for report</returns>
        public SourceCollection GetData(string name, IEnumerable data)
        {
            return GetData(new Dictionary<string, IEnumerable> {{name, data}});
        }
        /// <summary>
        /// Get data from some <see cref="IEnumerable"/> sources
        /// </summary>
        /// <param name="data">Collection of pairs name of source / data</param>
        /// <returns>Source for report</returns>
        public SourceCollection GetData(Dictionary<string, IEnumerable> data)
        {
            IList<ISource> sourceCollection = new List<ISource>(data.Count);
            foreach (var enumerable in data)
            {
                sourceCollection.Add(enumerable.Value.ToReportSource(enumerable.Key));
            }
            return new SourceCollection(sourceCollection);
        }
    }
}
