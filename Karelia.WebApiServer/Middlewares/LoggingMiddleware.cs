using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BusinessFramework.Contracts;
using Microsoft.Owin;

namespace Karelia.WebApiServer.Middlewares
{
    /// <summary>
    ///     OWIN middleware for Tracing
    /// </summary>
    internal sealed class LoggingMiddleware : OwinMiddleware
    {
        public LoggingMiddleware(OwinMiddleware next, ILogger logger)
            : base(next)
        {
            Logger = logger;
        }

        private ILogger Logger { get; set; }

        public override async Task Invoke(IOwinContext context)
        {
            var request = context.Request.Method + " " + context.Request.Uri;
            Logger.Trace("Requesting: " + request);

            var stopwatch = Stopwatch.StartNew();
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception exc)
            {
                Logger.Error("Error processing request " + request, exc);
                throw;
            }
            stopwatch.Stop();

            if (context.Response.StatusCode <= 400)
            {
              Logger.Trace(string.Format("Request:{0}; response: {1} - {2}; elapsed:{3}ms; size:{4}kb",
                    request, context.Response.StatusCode, context.Response.ReasonPhrase, stopwatch.ElapsedMilliseconds, context.Response.ContentLength / 1024));
            }
            else
            {
              Logger.Error(string.Format("Request: {0}; response:{1}; elapsed:{2}ms; size:{3}kb",
                  request, context.Response.StatusCode, stopwatch.ElapsedMilliseconds, context.Response.ContentLength / 1024));
            }
        }
    }
}