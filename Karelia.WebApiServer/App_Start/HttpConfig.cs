using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using BusinessFramework.Contracts;
using Newtonsoft.Json.Serialization;

namespace Karelia.WebApiServer
{
    /// <summary>
    /// Common http configuration
    /// </summary>
    internal static class HttpConfig
    {
        /// <summary>
        /// Configure common http settings
        /// </summary>
        /// <param name="config"></param>
        public static void Configure(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings = JsonSettings.CreateSettings();
#if DEBUG
            config.Formatters.JsonFormatter.SerializerSettings.TraceWriter = new DebugTraceWriter();
#endif
            // Remove xml this will make json the default and your life easier (unless you really need to support xml)
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "text/xml"));
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml"));
        }

        /// <summary>
        /// Serializer debug tracing
        /// </summary>
        private sealed class DebugTraceWriter : ITraceWriter
        {
            /// <summary>
            ///     Writes the specified trace level, message and optional exception.
            /// </summary>
            /// <param name="level">The <see cref="T:System.Diagnostics.TraceLevel" /> at which to write this trace.</param>
            /// <param name="message">The trace message.</param>
            /// <param name="ex">The trace exception. This parameter is optional.</param>
            public void Trace(TraceLevel level, string message, Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            public TraceLevel LevelFilter
            {
                get { return TraceLevel.Warning; }
            }
        }
    }
}