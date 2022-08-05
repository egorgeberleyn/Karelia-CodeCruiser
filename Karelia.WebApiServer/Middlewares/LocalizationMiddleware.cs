using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin;
using Westwind.Utilities;

namespace Karelia.WebApiServer.Middlewares
{
    /// <summary>
    ///     OWIN middleware for set current culture
    /// </summary>
    internal sealed class LocalizationMiddleware : OwinMiddleware
    {
        /// <summary>
        ///     Instantiates the middleware with an optional pointer to the next component.
        /// </summary>
        /// <param name="next" />
        public LocalizationMiddleware(OwinMiddleware next)
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
            var headers = context.Request.Headers;

            if (headers.ContainsKey("Accept-Language"))
            {
                var acceptLanguage = headers["Accept-Language"];
                var culture = Thread.CurrentThread.CurrentCulture.Name;
                StringWithQualityHeaderValue langValue;
                if (StringWithQualityHeaderValue.TryParse(acceptLanguage, out langValue))
                {
                    culture = langValue.Value;
                    WebUtils.SetUserLocale(culture);
                }
            }
            await Next.Invoke(context);
        }
    }
}