class WelcomeController {
    constructor($state, $rootScope, loginModalService, runtimeStates) {
        "ngInject";
        Object.assign(this, { $state, $rootScope, loginModalService, runtimeStates });
    }

    $onInit() {
        if (this.$state.current.data && this.$state.current.data.login) {
            this.loginModalService.showLoginForm().then(modal => {
                this.modal = modal;
                this.modal.promise.then(user => {
                    this.$rootScope.currentUser = user;
                    const firstState = this.runtimeStates.getFirstState();
                    if (firstState) {
                        this.$state.go(firstState);
                    } else {
                        this.$state.go('app');
                    }
                }).catch(() => {

                });
            });
        } else if (this.$state.current.data && this.$state.current.data.register) {
            this.loginModalService.showRegisterForm().then(modal => {
                this.modal = modal;
                this.modal.promise.then(() => {
                    this.$state.go('login');
                }).catch(() => {

                });
            });
        } else if (this.$state.current.data && this.$state.current.data.reset) {
            this.loginModalService.showResetForm().then(modal => {
                this.modal = modal;
                this.modal.promise.then(() => {
                    this.$state.go('login');
                }).catch(() => {

                });
            });
        }
        else if (this.$state.current.data && this.$state.current.data.restore) {
            this.loginModalService.showInputEmailForm().then(modal => {
                this.modal = modal;
                this.modal.promise.then(() => {
                    this.$state.go('login');
                }).catch(() => {

                });
            });
        }
    }

    $onDestroy() {
        if (this.modal) {
            this.modal.hide();
        }
    }
}

export default {
    template: "<div></div>",
    controller: WelcomeController
};

