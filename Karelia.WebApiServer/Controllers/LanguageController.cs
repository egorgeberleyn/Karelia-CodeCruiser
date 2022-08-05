using System.Web.Http;
using System.Web.Http.Results;
using BusinessFramework.Contracts.Culture;
using BusinessFramework.Contracts.GuiSettings.Json;


namespace Karelia.WebApiServer.Controllers
{
    /// <summary>
    ///     Get supported languages
    /// </summary>
    [AllowAnonymous]
    public class LanguageController : ApiController
    {
        /// <summary>
        ///     Get supported languages
        /// </summary>
        /// <returns></returns>
        public JsonResult<Language[]> Get()
        {
            var result = new []
            {
                new Language {Title = "ENU", NativeDescription = "English (United States)", Locale = "en-US"},
            };

			return Json(result, GuiSettingsJsonSettings.WriteSettings);
        }
    }
}