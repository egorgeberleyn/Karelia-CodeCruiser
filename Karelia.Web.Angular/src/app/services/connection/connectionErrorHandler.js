export default class ConnectionErrorHandler {
    constructor(messageBoxService, $translate) {
        "ngInject";

        Object.assign(this, {messageBoxService, $translate});
        this.messageDialog = null;

    }

    showLostConnectionDialog() {
        if (this.messageDialog === null) {
            this.messageDialog = this.messageBoxService.show(this.$translate.instant('lost_connection_dialog_title'),
                this.$translate.instant('lost_connection_dialog_message'),
                this.$translate.instant('lost_connection_dialog_ok_button'),
                this.$translate.instant('lost_connection_dialog_cancel_button'));

            return this.messageDialog.then(result => {
                this.messageDialog = null;
                return result;
            });
        } else {
            return this.messageDialog;
        }
    }
}
