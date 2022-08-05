import template from "./wizard-checkbox.html"
import { BaseWizardElement, getWizardElementDeclaration } from "../base/baseWizardElement";
class CheckBoxController extends BaseWizardElement {
    $onInit() {
        this.init();
    }
}
export default getWizardElementDeclaration(template, CheckBoxController);
