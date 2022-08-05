export default class WizardManagementService {
    constructor(httpService, wizardInvokeService, $translate) {
        "ngInject";
        this.httpService = httpService;
        this.wizardInvokeService = wizardInvokeService;
        this.$translate = $translate;
    }

    _buildTitle(entityName, titleKey) {
        return this.$translate.instant(titleKey);
    }

    /**
     * Creating new entity by wizard
     */
    createNew(options) {
        return this.wizardInvokeService.openWizard(Object.assign(options, {
            title: this._buildTitle(options.service.entityName, 'wizard_create_caption'),
            isNew: true,
            readonly: false
        }));
    }
    /**
     * Edit entity by wizard
     */
    edit(options) {
        return this.wizardInvokeService.openWizard(Object.assign(options, {
            title: this._buildTitle(options.service.entityName, 'wizard_edit_caption'),
            isNew: false,
            readonly: false
        }));
    }
    /**
     * View entity by wizard(Readonly mode)
     */
    view(options) {
        return this.wizardInvokeService.openWizard(Object.assign(options, {
            title: this._buildTitle(options.service.entityName, 'wizard_view_caption'),
            isNew: false,
            readonly: true,
            commitOnClose: false
        }));
    }
}

