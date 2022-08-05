using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using BusinessFramework.WebAPI.Common.Controllers;
using BusinessFramework.WebAPI.Common.Request;
using BusinessFramework.WebAPI.Contracts.Files;
using BusinessFramework.WebAPI.Contracts.Security;

namespace Karelia.WebAPI.Controllers.Sys
{
    /// <summary>
    ///     Controller for working with files
    /// </summary>
    [RoutePrefix("api/Files")]
    public sealed class FilesController : AbstractApiController
    {
        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="fileService"></param>
        /// <param name="requestInitializer"></param>
        /// <param name="securityService"></param>
        public FilesController(IFilesService fileService, IRequestStorageInitializer requestInitializer, ICommonSecurityService securityService)
            : base(requestInitializer, securityService)
        {
            FileService = fileService;
        }
        #region Dependencies
        private IFilesService FileService { get; set; }
        #endregion
        /// <summary>
        ///     Download stored file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int key)
        {
            try
            {
                var file = FileService.GetFile(key);
                if (file == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                var message = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(file.Storage.Stream)
                };

                message.Content.Headers.ContentLength = file.Storage.Stream.Length;
                message.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = HttpUtility.UrlDecode(file.Link.FileName),
                    Size = file.Storage.Stream.Length
                };

                return message;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(ex.Message)
                };
            }
        }
    }
}
