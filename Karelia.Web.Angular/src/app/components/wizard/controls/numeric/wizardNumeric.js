import template from "./wizard-numeric.html"
import { getWizardElementDeclaration, BaseWizardElement } from "../base/baseWizardElement";
class WizardNumericController extends BaseWizardElement {
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
export default getWizardElementDeclaration(template, WizardNumericController);

