using System.Net.Mail;
using BusinessFramework.WebAPI.Contracts.Notifiers;
using BusinessFramework.WebAPI.Contracts.Security;
using Karelia.WebAPI.Contracts;
using Karelia.WebAPI.Properties;

namespace Karelia.WebAPI.Security
{
    /// <summary>
    ///     Service for confirmation user emails
    /// </summary>
    public sealed class EmailConfirmationService : IEmailConfirmationService
    {
        private IWebUtilityService WebUtilityService { get; }
        private IAppSettingsService SettingsService { get; }
        private INotifierManager NotifierManager { get; }
        private readonly string _clientHost;

        /// <summary>
        ///     C-tor
        /// </summary>
        public EmailConfirmationService(IAppSettingsService appSettingsService,
            INotifierManager notifierManager,
            IWebUtilityService webUtilityService)
        {
            WebUtilityService = webUtilityService;
            SettingsService = appSettingsService;
            NotifierManager = notifierManager;
            //TODO get host name
            _clientHost =
                string.IsNullOrWhiteSpace(appSettingsService.WebClientAngularPort)
                    ? appSettingsService.WebApiHost
                    : $"{appSettingsService.WebApiHost}:{appSettingsService.WebClientAngularPort}";
        }

        /// <summary>
        ///     Send email for the confirm email
        /// </summary>
        public void SendConfirmationMail(ISysUser sysUser)
        {
            if (Notifiers.SystemNotifier == null)
            {
                return;
            }

            var settings = new EmailNotifierSettings();
            settings.ToList.Add(new MailAddress(sysUser.EMail));

            var link = $"{_clientHost}/#!/confirm?email={WebUtilityService.UrlEncode(sysUser.EMail)}&emailToken={WebUtilityService.UrlEncode(sysUser.EmailToken)}";
            settings.Subject = CommonResources.EmailConfirmation_Subject;
            settings.Message = string.Format(CommonResources.EmailConfirmation_Body,
                sysUser.DisplayName,
                SettingsService.AppName,
                link,
                $"{_clientHost}/#!/login",
                sysUser.AccountName);

            NotifierManager.Notify(Notifiers.SystemNotifier, settings);
        }

        /// <summary>
        ///     Send email for reset password
        /// </summary>
        /// <param name="userDisplayName">User name</param>
        /// <param name="email">User email</param>
        /// <param name="token">Token</param>
        public void SendResetPasswordEmail(string userDisplayName, string email, string token)
        {
            if (Notifiers.SystemNotifier == null)
            {
                return;
            }

            var settings = new EmailNotifierSettings();
            settings.ToList.Add(new MailAddress(email));
            var link = $"{_clientHost}/#!/reset?token={WebUtilityService.UrlEncode(token)}";
            settings.Subject = CommonResources.ResetPassword_Subject;
            settings.Message = string.Format(CommonResources.ResetPassword_Body,
                userDisplayName,
                SettingsService.AppName,
                link);
            NotifierManager.Notify(Notifiers.SystemNotifier, settings);
        }

        /// <summary>
        ///     Confirm email
        /// </summary>
        public bool ConfirmEmail(ISysUser user, string emailToken)
        {
            return user != null && !user.IsEmailConfirmed && user.EmailToken.Equals(WebUtilityService.UrlDecode(emailToken));
        }
    }
}