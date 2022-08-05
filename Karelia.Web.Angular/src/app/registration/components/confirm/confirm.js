import settingsService from './../../../services/common/settingsService';
class ConfirmEmailController {
    constructor($stateParams, httpService, messageBoxService, $state, startUpInitService, $rootScope) {
        'ngInject';
        this.$stateParams = $stateParams;
        this.httpService = httpService;
        this.messageBoxService = messageBoxService;
        this.$state = $state;
        this.startUpInitService = startUpInitService;
        this.$rootScope = $rootScope;
    }

    $onInit() {
        this.httpService.get(`ConfirmEmail?email=${this.$stateParams.email}&emailToken=${this.$stateParams.emailToken}&clientId=web`)
            .then(result => {
                if (result && result.status === 200 && result.data && result.data.access_token) {
                    settingsService.saveUserInformation(result.data.userName, result.data.access_token);
                    this.$rootScope.currentUser = result.data.userName;
                    this.startUpInitService.afterLoginInit().then(() => {
                        this.messageBoxService.showMessage('Success', 'Email confirmed').then((result) => {
                            this.$state.go('app');
                        });
                    });
                 }
            }).catch(error => {
                this.messageBoxService.showMessage('Error', 'Email didnot confirmed.').then(() => {
                    this.$state.go('login');
                });
        });
    }
}
export default {
    template: '<div></div>',
    controller: ConfirmEmailController
}