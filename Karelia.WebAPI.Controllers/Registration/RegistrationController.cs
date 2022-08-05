using System;
using System.Web.Http;
using System.Linq;
using BusinessFramework.Contracts.DataObjects;
using BusinessFramework.WebAPI.Common.Controllers;
using BusinessFramework.WebAPI.Common.Request;
using BusinessFramework.WebAPI.Contracts.Security;
using System.Net;
using System.Net.Http;
using BusinessFramework.WebAPI.Contracts.Services;
using Newtonsoft.Json.Linq;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;
using Karelia.WebAPI.Contracts.Security;
using Karelia.WebAPI.Controllers.Properties;

namespace Karelia.WebAPI.Controllers.Registration
{
    /// <summary>
    /// Registration controller
    /// </summary>
    [AllowAnonymous]
    public sealed class RegistrationController : AbstractApiController
    {
        readonly ITokenGenerationService _tokenGenerationService;
        readonly IWebApiSettingsService _webApiSettingsService;
        readonly IPostRegistrationActionService _postRegistrationActionService;
        readonly ISysUserRepository _sysUserRepository;
        readonly IEmailConfirmationService _emailConfirmationService;

        /// <summary>
        /// Ctor
        /// </summary>
        public RegistrationController(
            ITokenGenerationService tokenGenerationService,
            IWebApiSettingsService webApiSettingsService,
            IPostRegistrationActionService postRegistrationActionService,
            IEmailConfirmationService emailConfirmationService,
            ISysUserRepository sysUserRepository,
            IRequestStorageInitializer requestInitializer,
            ICommonSecurityService securityService)
            : base(requestInitializer, securityService)
        {
            _tokenGenerationService = tokenGenerationService;
            _webApiSettingsService = webApiSettingsService;
            _postRegistrationActionService = postRegistrationActionService;
            _sysUserRepository = sysUserRepository;
            _emailConfirmationService = emailConfirmationService;
        }

        /// <summary>
        /// Generate report "ReportWithParameters"
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Register")]
        public HttpResponseMessage Register([FromBody] RegistrationModel model)
        {
            if (!_webApiSettingsService.AllowRegistration)
                return new HttpResponseMessage(HttpStatusCode.Forbidden);

            SysUser user = _sysUserRepository.Set().FirstOrDefault(u => u.AccountName.Equals(model.UserName) || u.EMail.Equals(model.Email));

            if (String.IsNullOrWhiteSpace(model.UserName) ||
                user != null && user.AccountName.Equals(model.UserName))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, CommonResources.RegistrationValidation_UserNameInvalid);

            if (String.IsNullOrWhiteSpace(model.Email) ||
                user != null && user.EMail.Equals(model.Email))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, CommonResources.RegistrationValidation_EmailInvalid);

            if (String.IsNullOrWhiteSpace(model.Password) ||
                String.IsNullOrWhiteSpace(model.ConfirmPassword) ||
                !model.Password.Equals(model.ConfirmPassword))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, CommonResources.RegistrationValidation_PasswordInvalid);

            SysUser entity = new SysUser
            {
                AccountName = model.UserName,
                EMail = model.Email,
                Password = model.Password,
                DisplayName = model.UserName
            };
            entity = _sysUserRepository.Create(entity);
            _sysUserRepository.Save();

            return GetObjectResult(ObjectOperationType.Create, entity);
        }

        /// <summary>
        /// Confirm email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="emailToken"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ConfirmEmail")]
        public HttpResponseMessage ConfirmEmail(String email, String emailToken, String clientId)
        {
            if (_webApiSettingsService.AllowRegistration && _webApiSettingsService.UseEmailVerification)
            {
                SysUser user = _sysUserRepository.Set().FirstOrDefault(u => u.EMail == email || u.AccountName == email);
                if (user != null && _emailConfirmationService.ConfirmEmail(user, emailToken))
                {
                    user.IsEmailConfirmed = true;
                    _sysUserRepository.Update(user);
                    _postRegistrationActionService.OnUserRegistered(user);
                    _sysUserRepository.Save();

                    JObject tokenResponse = _tokenGenerationService.GenerateTokenResponse(user.Id.ToString(), clientId, user.AccountName);

                    return Request.CreateResponse(HttpStatusCode.OK, tokenResponse);
                }

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Email not confirmed");
            }

            return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Not supported");
        }

        /// <summary>
        /// Registartion model
        /// </summary>
        public class RegistrationModel
        {
            /// <summary>
            /// Email
            /// </summary>
            public String Email { get; set; }
            /// <summary>
            /// Password
            /// </summary>
            public String Password { get; set; }
            /// <summary>
            /// Confirm password
            /// </summary>
            public String ConfirmPassword { get; set; }
            /// <summary>
            /// User name
            /// </summary>
            public String UserName { get; set; }
        }
    }
}
