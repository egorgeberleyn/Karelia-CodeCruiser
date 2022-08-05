import template from "./wizard-drop-down-list.html"
import BaseSelectController from "./../base/baseWizardSelectController"
import { getWizardElementDeclaration } from "../base/baseWizardElement";

class WizardDropDownListController extends BaseSelectController{
    constructor($scope, kendoDataSourceService){
        "ngInject";
        super($scope)
        this.kendoDataSourceService = kendoDataSourceService;
        this.$scope = $scope;
    }

    $onInit(){
        this.init();
        this.$scope.model = this.model;
        this.initSourceDependencies();
        this.dataSource = this.kendoDataSourceService.getBaseDataSource(this.field.dataSourcePath, this.field.sourceFilter)
    }
}
export default getWizardElementDeclaration(template, WizardDropDownListController)

