using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using ColoredConsole;
using Microsoft.Owin;

namespace Karelia.WebApiServer.Middlewares
{
    /// <summary>
    /// OWIN middleware for Tracing
    /// </summary>
    internal sealed class TraceMiddleware : OwinMiddleware
    {
        /// <summary>
        ///     Instantiates the middleware with an optional pointer to the next component.
        /// </summary>
        /// <param name="next" />
        public TraceMiddleware(OwinMiddleware next)
            : base(next)
        {
        }
        /// <summary>
        ///     Process an individual request.
        /// </summary>
        /// <param name="context" />
        /// <returns />
        public override async Task Invoke(IOwinContext context)
        {
            var verb = GetVerb(context.Request.Method);

            ColorConsole.WriteLine("Requesting: ".DarkGray(), verb, " ", context.Request.Uri.ToString());
            var stopwatch = Stopwatch.StartNew();
            await Next.Invoke(context);
            stopwatch.Stop();
            ColorConsole.WriteLine("Response(".DarkGray(), string.Format("{0}ms", stopwatch.ElapsedMilliseconds).DarkCyan(), "): ".DarkGray()
                , verb, " ", GetStatusCode(context.Response.StatusCode));
        }
        private static ColorToken GetVerb(string method)
        {
            method = method.ToUpperInvariant();

            switch (method)
            {
                case "GET":
                    return method.DarkCyan();
                case "PUT":
                    return method.DarkGreen();
                case "POST":
                    return method.DarkMagenta();
                case "DELETE":
                    return method.DarkRed();
            }
            return method.DarkYellow();
        }

        private static ColorToken GetStatusCode(int statusCode)
        {
            if (Enum.IsDefined(typeof (HttpStatusCode), statusCode))
            {
                var code = (HttpStatusCode) statusCode;
                var codeString = string.Format(@"{0}({1})", statusCode, code);

                return statusCode < 400
                    ? codeString.Green()
                    : codeString.DarkRed();
            }
            return statusCode < 400
                ? statusCode.ToString().Green()
                : statusCode.ToString().DarkRed();
        }
    }
}