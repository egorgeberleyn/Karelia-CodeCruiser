import template from './wizard.html'

class WizardController {
    constructor($scope, $timeout, modalWindowService, serverErrorProcessor, wizardSaveService) {
        "ngInject";
        Object.assign(this, {
            $scope,
            $timeout,
            modalWindowService,
            serverErrorProcessor,
            wizardSaveService
        });
    }

    $doCheck() {
        this.wizardContext.refreshLinkStates();
    }

    selectSection(index) {
        for (let i = 0; i < this.wizardContext.menuSections.length; i++) {
            const section = this.wizardContext.menuSections[i];
            if (section.index === index) {
                this.wizardContext.state.selectedSection = section;
                this.wizardContext.state.openedSection = null;
                break;
            }
            if (section.sections && section.sections.length > 0) {
                for (let j = 0; j < section.sections.length; j++) {
                    if (section.sections[j].index === index) {
                        this.wizardContext.state.selectedSection = section.sections[j];
                        this.wizardContext.state.openedSection = section;
                        break;
                    }
                }
            }
        }
        this.wizardContext.listenersPageSelectionChanged.forEach(callBack => {
            callBack(index);
        });
        //We need to run digest cycle because kendo don't do it
        this.$timeout(() => {
            this.$scope.$digest();
        });
    }

    closeClicked() {
        if (this.wizardContext.commitOnClose){
            this.modalWindowService.hide(this.$scope.$parent.$id, {
                complete: false
            });
        } else {
            this.modalWindowService.confirm(this.$scope.$parent.$id, {
                complete: false
            });
        }
    }

    finishClicked() {
        if (this.wizardContext.commitOnClose) {
						this.wizardContext.state.saving = true;
            const savePromise = this.wizardSaveService.save(this.wizardContext.model, this.wizardContext.service.domainControllerName);
            this.serverErrorProcessor.process(savePromise)
                .then(result => {
										this.modalWindowService.confirm(this.$scope.$parent.$id, result);
										this.wizardContext.state.saving = false;
								})
								.catch(() => {
									this.wizardContext.state.saving = false;
								});
        } else {
            this.modalWindowService.confirm(this.$scope.$parent.$id, {
                complete: true,
                model: this.wizardContext.model
            });
        }
    }
}

export default {
	template: template,
	bindings: {
		wizardContext: '='
	},
	transclude: true,
	controller: WizardController
}