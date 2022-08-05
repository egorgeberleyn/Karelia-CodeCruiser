import template from "./wizard-page.html"

class WizardPageController{
    constructor($scope, $timeout, $element){
        "ngInject";
        Object.assign(this, {$scope, $timeout, $element});
    }

    $doCheck(){
        if (this.wizardContext.state.selectedSection.index === this.page.index) {
            this.$element.show();
            if (this.currentForm) {
                if (!this.page.noValidate) {
                    this.wizardContext.pageValidationStateChanged(this.page.index, this.currentForm.$invalid);
                } else {
                    this.wizardContext.pageValidationStateChanged(this.page.index, false);
                }
            } else {
                this.wizardContext.pageValidationStateChanged(this.page.index, true);
            }
            this.wizardContext.refreshLinkStates();
        } else {
            this.$element.hide();
        }
    }

    $onInit(){
        this.page = this.wizard.wizardContext.pages.find(p => p.name === this.name);
        this.wizardContext = this.wizard.wizardContext;
        this.wizardContext.listenersPageSelectionChanged.push(index => {
            if (index === this.page.index) {
                this.wizardContext.pageValidationStateChanged(this.page.index, this.$scope[this.name].$invalid && !this.page.noValidate);
            }
        });

        this.$timeout(() => {
            this.currentForm = this.$scope[this.name];
            this.wizardContext.refreshLinkStates();
        });
    }
}

export default {
    template: template,
    transclude: true, 
    bindings: {
        name: "@"
    },
    require: {
        wizard: '^wizard'
    },
    controller: WizardPageController
}
