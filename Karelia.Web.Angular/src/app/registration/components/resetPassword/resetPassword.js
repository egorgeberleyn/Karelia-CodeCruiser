import template from './resetPassword.html'
class ResetPasswordController{
    constructor($scope, $translate, resetPasswordService, $stateParams, messageBoxService, $state){
        'ngInject';
        this.resetPasswordService = resetPasswordService;
        this.$stateParams = $stateParams;
        this.messageBoxService = messageBoxService;
        this.$state = $state;
        this.$translate = $translate;

        Promise.all([
            $translate('reset_password.restore_button_caption'),
            $translate('reset_password.password_field'),
            $translate('reset_password.confirm_password_field')
        ]).then(results => {
            [this.restorePasswordButton,
            this.passwordCaption,
            this.confirmPasswordCaption] = results; 
            $scope.$apply();
        });
    }

    restorePassword(password, confirmPassword) {
        this.loading = true;
        this.resetPasswordService.resetPasswrod(password, confirmPassword, this.$stateParams.token)
            .then(result => {
                this.loading = false;
                let message = null;
                if (result.status === 200) {
                    message = this.$translate.instant('reset_password.password_set_success');
                } else {
                    message = "Error";
                }
                return this.messageBoxService.showInfoMessage(message).then(() => {
                    this.$state.go('login');
                });
            });
    }

}

export default {
    template,
    controller: ResetPasswordController
}