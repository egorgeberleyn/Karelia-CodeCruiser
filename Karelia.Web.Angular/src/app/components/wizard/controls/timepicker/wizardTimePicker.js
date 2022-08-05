import template from "./wizard-time-picker.html"
import { BaseWizardElement, getWizardElementDeclaration } from "../base/baseWizardElement";

class WizardTimePickerController extends BaseWizardElement{
    constructor($scope){
        "ngInject";
        super();
        this.$scope = $scope;
    }
    $onInit(){
        this.init();
        this.$scope.model = this.model;
    }
    blur() {
        this.parentForm[this.field.name].$touched = true;
    }
}

export default getWizardElementDeclaration(template, WizardTimePickerController);

