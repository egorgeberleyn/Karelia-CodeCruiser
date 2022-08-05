using System.Web.Http;

namespace Karelia.WebApiServer
{
    /// <summary>
    /// Web Api configuration
    /// </summary>
    internal static class WebApiConfig
    {
        /// <summary>
        /// Configure web api settings
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(HttpConfiguration configuration)
        {
            //NOTE: All web api and odata controllers marked by Authorize attribute
            configuration.Filters.Add(new AuthorizeAttribute());
            
            configuration.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
        }
    }
}