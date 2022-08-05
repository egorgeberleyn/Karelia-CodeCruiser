import template from "./wizard-datetime-picker.html"
import { BaseWizardElement, getWizardElementDeclaration } from "../base/baseWizardElement";

class WizardDateTimePickerController extends BaseWizardElement{
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

export default getWizardElementDeclaration(template, WizardDateTimePickerController);

