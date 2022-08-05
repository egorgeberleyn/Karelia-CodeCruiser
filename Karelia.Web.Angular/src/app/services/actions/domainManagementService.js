import progressService from './../common/progressService';

export default class DomainManagementService{
    constructor($q, $translate, messageBoxService, httpService) {
        "ngInject";
        Object.assign(this, {$q, $translate, messageBoxService, httpService});
    }

    /**
     * Deleting object common method
     * @constructor
     * @param {string} entityControllerName - Name of api entity controller
     * @param {array} author - Array of entity keys
     * @return promise
     */
    delete(entityControllerName, dataModelKeys) {
        const caption = this.$translate.instant('delete_form_caption');
        const message = this.$translate.instant('delete_form_message');
        const okButton = this.$translate.instant('delete_form_ok_button');
        const cancelButton = this.$translate.instant('delete_form_cancel_button');
        progressService.hide();
        return this.messageBoxService.show(caption, message, okButton, cancelButton).then(() => {
            return this.httpService.delete(entityControllerName, dataModelKeys);
        });
    }
}

