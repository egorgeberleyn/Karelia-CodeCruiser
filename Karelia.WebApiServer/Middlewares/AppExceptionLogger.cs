using System.Web.Http.ExceptionHandling;
using BusinessFramework.Contracts;

namespace Karelia.WebApiServer.Middlewares
{
    internal sealed class AppExceptionLogger : ExceptionLogger
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Web.Http.ExceptionHandling.ExceptionLogger" /> class.
        /// </summary>
        public AppExceptionLogger(ILogger logger)
        {
            Logger = logger;
        }

        private ILogger Logger { get; set; }

        public override void Log(ExceptionLoggerContext context)
        {
            var request = context.Request.Method + " " + context.Request.RequestUri;
            Logger.Error(context.Exception, "Request:" + request);
            base.Log(context);
        }

        public override bool ShouldLog(ExceptionLoggerContext context)
        {
            return true;
        }
    }
}