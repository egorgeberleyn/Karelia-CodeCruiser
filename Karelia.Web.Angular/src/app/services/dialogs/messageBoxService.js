import screenSizeService from "../helpers/screenSizeService";

export default class MessageBoxService {
    constructor(modalWindowService, $translate) {
        "ngInject";
        this.modalWindowService = modalWindowService;
        this.translate = $translate;
    }

    showConfirmation(title, message) {
        const okButtonText = this.translate.instant('confirmation_ok_button_text');
        const cancelButtonText = this.translate.instant('confirmation_cancel_button_text');
        return this.show(title, message, okButtonText, cancelButtonText);
    }

    showMessage(title, message, details) {
        const okButtonText = this.translate.instant('confirmation_ok_button_text');
        return this.show(title, message, okButtonText, null, details);
    }

    showInfoMessage(message, details) {
        const title = this.translate.instant('info_message_title');
        return this.showMessage(title, message, details);
    }

    _normalizeString(value){
        return value.replace(/\'/g, "`");
    }

    show(title, message, okButtonText, cancelButtonText, details) {
        const screenWidth = screenSizeService.getScreenSize().width;
        const options = {
            template: `<confirmation-dialog 
            message="${message}" ok-text='${okButtonText}'
            ${(cancelButtonText ? "cancel-text='" + cancelButtonText + "' " : "" )}
            ${(details ? "details='" + this._normalizeString(details) + "' " : "")}></confirmation-dialog>`,
            title: title,
            width:  screenWidth > 600? "600px": screenWidth + 'px'
        };
        return this.modalWindowService.show(options).promise;
    }
}
