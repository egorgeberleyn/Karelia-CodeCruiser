using System;
using System.Web.Http;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Karelia.Contracts.OData;

namespace Karelia.WebApiServer
{
    /// <summary>
    /// OData configuration
    /// </summary>
    internal static class ODataConfig
    {
        /// <summary>
        /// Configure OData settings
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(HttpConfiguration configuration)
        {
            var edmReader = new EdmModelReader();
            var edmModel = edmReader.ReadModel();

            ODataBatchHandler odataBatchHandler = new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer);
            configuration.MapODataServiceRoute("ODataRoute", "api/odata", edmModel, odataBatchHandler);
            configuration.SetTimeZoneInfo(TimeZoneInfo.Utc);
            configuration
              .Count(QueryOptionSetting.Allowed)
              .Filter(QueryOptionSetting.Allowed)
              .OrderBy(QueryOptionSetting.Allowed)
              .Select(QueryOptionSetting.Allowed)
              .MaxTop(null)
              .Expand(QueryOptionSetting.Disabled);
    }
    }
}