import loginTemplate from './login.html'
import config from '../../services/config/config';
import settingsService from '../../services/common/settingsService'

class LoginController {
    constructor(modalWindowService, httpService, $scope, $translate, downloadClientService, startUpInitService, $stateParams) {
        "ngInject";
        this.modalWindowService = modalWindowService;
        this.$stateParams = $stateParams;
        this.httpService = httpService;
        this.$scope = $scope;
        this.downloadClientService = downloadClientService;
        this.showDownloadClientLink = downloadClientService.showDownloadClientLink;
        this.startUpInitService = startUpInitService;
        Promise.all([
            $translate('login_form.name_field'),
            $translate('login_form.password_field'),
            $translate('login_form.submit_button'),
            $translate('download_client_button'),
            $translate('login_form.register_link_caption'),
            $translate('login_form.reset_password_link_caption')
        ]).then(results => {
            [this.nameCaption,
            this.passwordCaption,
            this.okButtonTitle,
            this.downloadButtonCaption,
            this.registerLinkCaption,
            this.resetPasswordLinkCaption] = results;
            $scope.$apply();
        });
        this.loading = false;
        this.showRegister = config.allowRegistration;
        this.showRestorePassword = config.allowPasswordRestore;
        this.model = {};
    }

    downloadClient() {
        this.downloadClientService.downloadClient();
    }

    submit(name, password) {
        this.loading = true;
        this.httpService.getToken(name, password)
            .then(result => {
                this.loading = false;
                if (result.status === 200 && result.data) {
                    settingsService.saveUserInformation(name, result.data.access_token, result.data.refresh_token, result.data.expires_in)
                    this.startUpInitService.afterLoginInit().then(() => {
                        this.modalWindowService.confirm(this.$scope.$parent.$id, name);
                    });
                } else {
                    this.$scope.loginForm.$invalid = true;
                    this.$scope.loginForm.$error.loginFailed = result.data.error;
                }
            });
    }

    resetPasswordClicked() {
        this.messageBox
    }
}

export default {
    template: loginTemplate,
    controller: LoginController
};

