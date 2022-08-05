import template from './register.html';

class RegisterComponentController {
    constructor($scope, $translate, registrationService, $state, messageBoxService, $stateParams) {
        'ngInject';
        this.messageBoxService = messageBoxService;
        this.registrationService = registrationService;
        this.$state = $state;
        this.$translate = $translate;
        this.$stateParams = $stateParams;
        Promise.all([
            $translate('register_form.register_button_caption'),
            $translate('register_form.email_field'),
            $translate('register_form.login_field'),
            $translate('register_form.password_field'),
            $translate('register_form.confirm_password_field'),
            $translate('register_form.login_link')
        ]).then(results => {
            [this.registerButtonTitle,
            this.emailCaption,
            this.loginCaption,
            this.passwordCaption,
            this.confirmPasswordCaption,
            this.loginLinkCaption] = results;
            $scope.$apply();
        });
    }

    register(email, userName, password, confirmPassword) {
        this.loading = true;
        const model = { email, userName, password, confirmPassword };
        if (this.$stateParams.parameters) {
            Object.assign(model, JSON.parse(this.$stateParams.parameters));
        }
        this.registrationService.registerUser(model)
            .then(result => {
                this.loading = false;
                if (result.status === 200) {
                    this.messageBoxService.showInfoMessage(this.$translate.instant("register_form.after_register_message")).then(() => {
                        this.$state.go('login');
                    });
                } else if (result.status === 400) {
                    this.error = result.data.Message;
                }
            }).catch(error => {
                console.log(error);
            });
    }
}

export default {
    template,
    controller: RegisterComponentController
}
