using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using BusinessFramework.WebAPI.Common.Controllers;
using BusinessFramework.WebAPI.Common.Request;
using BusinessFramework.WebAPI.Contracts.Security;
using BusinessFramework.WebAPI.Contracts.Services;
using Karelia.WebAPI.Contracts.DataObjects;
using Karelia.WebAPI.Contracts.Repositories;
using Karelia.WebAPI.Controllers.Properties;

namespace Karelia.WebAPI.Controllers.Registration
{
    /// <summary>
    /// Restore password
    /// </summary>
    [AllowAnonymous]
    public class RestorePasswordController: AbstractApiController
    {
        private readonly IWebApiSettingsService _webApiSeeSettingsService;
        private readonly IEmailConfirmationService _emailConfirmationService;
        private readonly ISysResetPasswordTokenRepository _resetPasswordTokenRepository;
        private readonly ISysUserRepository _sysUserRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        public RestorePasswordController(
            IWebApiSettingsService webApiSeeSettingsService,
            IEmailConfirmationService emailConfirmationService,
            ISysResetPasswordTokenRepository resetPasswordTokenRepository,
            ISysUserRepository sysUserRepository,
            IRequestStorageInitializer requestInitializer,
            ICommonSecurityService securityService) 
            : base(requestInitializer, securityService)
        {
            _webApiSeeSettingsService = webApiSeeSettingsService;
            _emailConfirmationService = emailConfirmationService;
            _resetPasswordTokenRepository = resetPasswordTokenRepository;
            _sysUserRepository = sysUserRepository;
        }

        /// <summary>
        /// Action for reset password
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/SendResetPasswordLink")]
        public IHttpActionResult SendResetPasswordLink(string name)
        {
            if (_webApiSeeSettingsService.AllowPasswordRestore)
            {
                var user = _sysUserRepository.Set().FirstOrDefault(u => u.EMail == name || u.AccountName == name);
                if (user == null)
                {
                    return NotFound();
                }
                var token = new SysResetPasswordToken
                {
                    UserId = user.Id,
                    Token = Guid.NewGuid().ToString(),
                    IsExecuted = false,
                    ValidFrom = System.DateTimeOffset.Now
                };
                _resetPasswordTokenRepository.Create(token);
                _emailConfirmationService.SendResetPasswordEmail(user.DisplayName, user.EMail, token.Token);
                _resetPasswordTokenRepository.Save();
                return Ok();
            }
            return StatusCode(HttpStatusCode.Forbidden);
        }

        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="resetPasswordModel">Model</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ResetPassword")]
        public IHttpActionResult ResetPassword([FromBody] ResetPasswordModel resetPasswordModel)
        {
            if (_webApiSeeSettingsService.AllowPasswordRestore)
            {
                var token = _resetPasswordTokenRepository.Resolve(resetPasswordModel.Token);
                if (token == null)
                {
                    return NotFound();
                }
                if (resetPasswordModel.ConfirmPassword == resetPasswordModel.Password)
                {
                    var user = _sysUserRepository.GetByKey(token.UserId);
                    user.Password = resetPasswordModel.Password;
                    user.IsEmailConfirmed = true;
                     _sysUserRepository.Update(user);
                    token.IsExecuted = true;
                    _resetPasswordTokenRepository.Update(token);
                    _sysUserRepository.Save();
                    return Ok();
                }
                return BadRequest(CommonResources.RegistrationValidation_PasswordInvalid);
            }
            return StatusCode(HttpStatusCode.Forbidden);
        }

        #region Nested types
        /// <summary>
        /// Reset password model
        /// </summary>
        public class ResetPasswordModel
        {
            /// <summary>
            /// Token
            /// </summary>
            public string Token { get; set; }
            /// <summary>
            /// Password
            /// </summary>
            public string Password { get; set; }
            /// <summary>
            /// Confirm password
            /// </summary>
            public string ConfirmPassword { get; set; }
        }
        #endregion Nested types
    }
}
