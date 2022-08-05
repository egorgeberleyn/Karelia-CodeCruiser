import template from "./wizard-input.html"
import { BaseWizardElement, getWizardElementDeclaration } from "../base/baseWizardElement";
class WizardInputController extends BaseWizardElement{
    constructor($scope){
        "ngInject";
        super();
        this.$scope = $scope;
    }
    $onInit(){
        this.init();
        this.$scope.model = this.model;
    }
}
export default getWizardElementDeclaration(template, WizardInputController);
