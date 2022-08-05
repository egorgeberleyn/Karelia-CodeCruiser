import template from "./wizard-autocomplete.html"
import { getWizardElementDeclaration, BaseWizardElement } from "../base/baseWizardElement";
class WizardAutocompleteController extends BaseWizardElement{
    constructor(kendoDataSourceService) {
        "ngInject";
        super();
        this.kendoDataSourceService = kendoDataSourceService;
    }

    $onInit(){
        this.init();
        this.options = {
            dataTextField: this.field.displayField,
            filter: "contains",
            minLength: 3,
            dataSource: this.kendoDataSourceService.getBaseDataSource(this.field.dataSourcePath, this.field.sourceFilter)
        };
    }
}

export default getWizardElementDeclaration(template, WizardAutocompleteController);

