import progressService from './../common/progressService'
import angular from "angular";
import screenSizeService from '../helpers/screenSizeService';
import valueFormatter from '../formatters/valueFormatter';
import { createWizardContext } from '../../components/wizard/wizard/wizardService';
import { getWizardFields, createWizardPages } from '../../components/wizard/wizard/wizardPageFactory';

export default class WizardInvokeService {
    constructor(httpService, modalWindowService, $translate, $document) {
        "ngInject";
        Object.assign(this, { httpService, modalWindowService, $translate, $document });
    }

    getModel(controllerName, entityKey) {
        return this.httpService.get(controllerName + "?key=" + this.httpService.urlEncodeParameter(entityKey[0]))
            .then(result => result.data);
    }

    getFieldList(wizardSettings) {
        let fields = [];
        wizardSettings.items.forEach(pageDescr => {
            fields = fields.concat(pageDescr.editors);
        });
        return fields;
    }

    openWizard(options) {
        if (options.onBeforeOpen) {
            options.onBeforeOpen();
        }
        progressService.show();
        const { service, entityKey } = options;
        return this.httpService.get(service.wizardSettingsControllerName)
            .then(result => {
                options.wizardSettings = result.data;
                if (!options.isNew) {
                    return this.getModel(service.domainControllerName, entityKey);
                } else {
                    return Promise.resolve(service.objectFactory.getNew());
                }
            })
            .then(model => valueFormatter.convertDatesToLocal(this.getFieldList(options.wizardSettings), model))
            .then(model => this._openWizardInternal(Object.assign(options, { model })));
    }

    openReportForm(wizardSettings) {
        return this._openWizardInternal({
            wizardSettings,
            readonly: false,
            isNew: true,
            title: "title",
            commitOnClose: false
        });
    }

    _openWizardInternal(options) {
        const size = screenSizeService.getScreenSize();
        let width = size.width;

        if (width > 800) {
            width = 800;
        }
        else if (width < 800 && width > 600) {
            width = width * 0.95;
        }
        try {
            return import(`./../../domain/templates/wizards/${options.service.template}.html`).then(template => {
                const { wizardSettings, model, isNew, setContextDefaults, contextParameters, readonly, service, commitOnClose } = options;
                const wizardContext = createWizardContext(wizardSettings, model, contextParameters, readonly, service, isNew, commitOnClose);
                if (setContextDefaults) {
                    setContextDefaults(wizardContext.model);
                }
                if (service) {
                    service.wizardInitializationService.setDefaults(contextParameters, wizardContext.model);
                }
                wizardContext.pages = createWizardPages(wizardSettings, readonly, wizardContext, service);
                wizardContext.fields = getWizardFields(wizardContext.pages);

                return this.modalWindowService.show({
                    template: `<wizard wizard-context="wizardContext">${template.default}</wizard>`,
                    title: options.title,
                    maximize: size.width <= 1200,
                    resizeCallback: (element) => {
                        return this._resize(element);
                    },
                    opened: () => {
                        progressService.hide();
                        if (options.onAfterOpen()) {
                            options.onAfterOpen();
                        }
                    },
                    width: width,
                    locals: { wizardContext }
                }).promise;
            })
        } catch (e) {
            return Promise.reject(e);
        }
    }

    _resize(element) {
        const size = screenSizeService.getScreenSize();
        const screenHeight = size.height;
        const wizardElement = element.find('.wizard');
        const contentWrapper = wizardElement.find('.wizard-content-wrapper');
        const wizardContent = contentWrapper.find('.wizard-content');
        const pages = wizardContent.find('wizard-page');
        const previousCss = wizardElement.attr("style");
        const body = this.$document.find('body').eq(0);
        wizardElement
            .css({
                position: 'absolute',
                visibility: 'hidden',
                display: 'block'
            });
        wizardElement.appendTo(body);
        let wizardHeight = wizardElement.outerHeight(true);
        let maxPageHeight = 0;
        for (let i = 0; i < pages.length; i++) {
            const pageSelector = angular.element(pages[i]);
            pageSelector.hide();
        }
        for (let i = 0; i < pages.length; i++) {
            const pageSelector = angular.element(pages[i]);
            pageSelector.show();
            maxPageHeight = Math.max(maxPageHeight, pageSelector.outerHeight(true));
            wizardHeight = Math.max(wizardHeight, wizardElement.outerHeight(true));
            pageSelector.hide();
        }
        wizardElement.attr("style", previousCss ? previousCss : "");
        wizardElement.appendTo(element);
        wizardElement.css({ height: '100%' })
        pages.css({ flex: '1', height: '100%' });
        return {
            height: screenHeight < (wizardHeight + 80) ? screenHeight * 0.9 : wizardHeight + 80
        };
    }
}