import template from "./wizard-multiline.html"
import { BaseWizardElement, getWizardElementDeclaration } from "../base/baseWizardElement";
class WizardMultilineController extends BaseWizardElement{
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
export default getWizardElementDeclaration(template, WizardMultilineController);
