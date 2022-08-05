import { BaseWizardElement } from "./baseWizardElement";
import connectionSettings from './../../../../services/config/connectionSettings';

export default class BaseWizardSelectController extends BaseWizardElement {
    constructor($scope){
        super();
        this.$scope = $scope;
		}
		
		onSelect(e) {
			this.$scope.model[this.field.name] = e.dataItem[this.field.valueField];
			this.parentForm[this.field.name].$touched = true;
			this.page.$doCheck();
		}

    initSourceDependencies(){
        if (this.field.sourceDependencies) {
            this.field.sourceDependencies.forEach(dep => {
                this.$scope.$watch('$ctrl.model.' + dep, () => {
                    if (this.$scope.select) {
                        if (this.field.serverFiltering) {
                            //TODO uodate datasource when serverFiltering = true
                        } else {
                            this.field.dataSourcePathRefresher();

                            // pass our DS path to kendo select

                            //this.dataSource.transport.read.url = this.field.dataSourcePath;
                            //this.$scope.select.dataSource.options.transport.read.url = this.field.dataSourcePath;
                            this.$scope.select.dataSource.transport.options.read.url = connectionSettings.baseApiOdataPath + this.field.dataSourcePath;
                            this.$scope.select.dataSource.read();

                            // TODO url doesn't recreate correct prefix = 'http://localhost:9370/api/odata/'. Instead it handles as relative path quering itself.
                        }
                    }
                });
            });
        }
    }
    blur () {
        this.parentForm[this.field.name].$touched = true;
    }
}

