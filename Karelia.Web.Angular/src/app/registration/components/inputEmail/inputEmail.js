import template from './inputmail.html'
class InputEmailController{
    constructor($scope, $translate, resetPasswordService, $state, messageBoxService, $stateParams){
        'ngInject';
        this.$state = $state;
        this.resetPasswordService = resetPasswordService;
        this.messageBoxService = messageBoxService;
        this.$translate = $translate;
        this.$stateParams = $stateParams;

        Promise.all([
            $translate.instant('reset_password.send_mail_caption'),
            $translate.instant('reset_password.input_email_caption'),
            $translate.instant('reset_password.login_caption_link')
        ]).then(results => {
            [this.restoreButtonTitle,
            this.emailCaption,
            this.loginLinkCaption] = results; 
            $scope.$apply();
        });
    }

    restorePassword(email){
        this.resetPasswordService.sendLink(email).then((result) => {
            let message = null;
            if (result.status === 200) {
                this.messageBoxService.showInfoMessage(this.$translate.instant("reset_password.instructions_were_sent")).then(() => {
                    this.$state.go('login');
                });
            }
        });
    }
}

export default {
    template,
    controller: InputEmailController
}