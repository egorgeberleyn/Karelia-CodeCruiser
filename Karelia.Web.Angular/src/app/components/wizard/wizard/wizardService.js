import dataTypeHelperService from '../../../services/helpers/dataTypeHelperService';
import { createWizardPages, getWizardFields } from './wizardPageFactory';
import { createNavigationMenu } from './wizardNavigationMenuFactory';

function createMenuStates(menuSections, service, wizardContext) {
    const menuLinksStates = [];
    menuSections.forEach((section) => {
        menuLinksStates[section.index] = {
            disable: false,
            visible: true
        };
        const visiblePropertyName = section.name + 'IsVisibleDependsOn';
        if (service[visiblePropertyName] && service[visiblePropertyName].length > 0) {
            menuLinksStates[section.index].visibilityCondition = () => {
                return service[section.name + 'IsVisible'](wizardContext);
            }
        }
    });
    return menuLinksStates;
}

function convertDates(page, model) {
    page.fields.forEach(field => {
        if (dataTypeHelperService.isDate(field.dataType) && model[field.name]) {
            model[field.name] = new Date(model[field.name]);
        }
    })
}

function prepareModel(pages, model) {
    if (pages && pages.length > 0) {
        pages.forEach(p => convertDates(p, model));
    }
}

export function createWizardContext(wizardSettings, model, contextParameters, readonly, service, isNew, commitOnClose) {
    const menuSections = createNavigationMenu(wizardSettings, isNew);
    model = model === null ? {} : model;
    const wizardContext = {
        wizardSettings,
        menuSections,
        service,
        isNew,
        commitOnClose,
        parameters: contextParameters,
        model,
        origin: angular.copy(model),
        readonly,
        listenersPageSelectionChanged: [],
        refreshLinkStates() {
            wizardContext.state.menuLinkStates.forEach(linkState => {
                if (linkState.visibilityCondition) {
                    linkState.visible = linkState.visibilityCondition(wizardContext);
                }
            })
        }
    };
    wizardContext.pageValidationStateChanged = (index, invalid) => {
        wizardContext.state.menuLinkStates[index].finishDisable = invalid;
        if (index < wizardContext.state.menuLinkStates.length - 1) {
            if (invalid) {
                for (let i = index + 1; i < wizardContext.state.menuLinkStates.length; i++) {
                    wizardContext.state.menuLinkStates[i].disable = true;
                }
            } else {
                for (let i = index + 1; i < wizardContext.state.menuLinkStates.length; i++) {
                    if (wizardContext.state.menuLinkStates[i].visible) {
                        wizardContext.state.menuLinkStates[i].disable = false;
                    }
                }
            }
        }
    }

    wizardContext.state = {
        menuLinkStates: createMenuStates(menuSections, service, wizardContext),
        openedSection: null,
        selectedSection: menuSections[0]
    };

    //We should convert dates b/c they come from server as strings
    if (!isNew) {
        prepareModel(wizardContext.pages, model);
    }

    return wizardContext;
}

