import template from "./wizard-combobox.html"
import BaseSelectController from "./../base/baseWizardSelectController"
import { getWizardElementDeclaration } from "../base/baseWizardElement";

class WizardComboboxController extends BaseSelectController{
    constructor($scope, kendoDataSourceService){
        "ngInject";
        super($scope);
        this.kendoDataSourceService = kendoDataSourceService;
		}
		
    $onInit(){
        this.init();
        this.$scope.model = this.model;
        this.initSourceDependencies();
        this.dataSource = this.kendoDataSourceService.getBaseDataSource(this.field.dataSourcePath, this.field.sourceFilter);
    }
}

export default getWizardElementDeclaration(template, WizardComboboxController);
