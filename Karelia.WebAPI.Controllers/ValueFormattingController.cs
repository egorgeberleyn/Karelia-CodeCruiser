using System.Linq;
using System.Web.Http.Results;
using BusinessFramework.Contracts.Formatting;
using BusinessFramework.WebAPI.Common.Controllers;
using BusinessFramework.WebAPI.Common.Request;
using BusinessFramework.WebAPI.Contracts.Security;

namespace Karelia.WebAPI.Controllers
{
    /// <summary>
    ///     Get value formats controller
    /// </summary>
    public sealed class ValueFormattingController : AbstractApiController
    {
        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="requestInitializer"></param>
        /// <param name="valueFormattingService"></param>
        /// <param name="securityService"></param>
        public ValueFormattingController(IRequestStorageInitializer requestInitializer, IValueFormattingService valueFormattingService, ICommonSecurityService securityService)
            : base(requestInitializer, securityService)
        {
            ValueFormattingService = valueFormattingService;
        }

        private IValueFormattingService ValueFormattingService { get; set; }

        /// <summary>
        ///     Get value formats
        /// </summary>
        /// <returns></returns>
        public JsonResult<ValueFormatting[]> Get()
        {
            return Json(ValueFormattingService.Formats.ToArray());
        }
    }
}