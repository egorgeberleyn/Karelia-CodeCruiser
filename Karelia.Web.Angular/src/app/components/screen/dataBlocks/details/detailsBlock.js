import template from "./details-block.html"
import detailsBuilderService from '../../../../services/screens/detailsBuilderService'
import BaseDataBlock from "../base/baseDataBlock";

class DetailsBlockController extends BaseDataBlock{
    constructor($scope, $rootScope, httpService, $element, $window, $injector) {
        "ngInject";
        super();
        Object.assign(this, {
            $scope,
            $rootScope,
            httpService,
            $element,
            $window,
            $injector
        });
    }

    $onInit(){
        this.contextState = this.screenCtrl.contextState;
        this.options = this.screenCtrl.blocks[this.name];

        const screenService = this.contextState.screenService;

        const filterExtractor = screenService[`${this.options.name}SourceFilter`];
        this.dataSourceFilter;
        if (filterExtractor)
            this.dataSourceFilter = filterExtractor(this.contextState);

        this.initVisibilityChecker(this.$scope, this.$element, this.fillContainers.bind(this));

        this.fields = detailsBuilderService.getFields(this.options.content.fields);

        this.rows = [];
        let currentRow = {fields: []};
        for (let i = 0; i < this.fields.length; i++) {
            currentRow.fields.push(this.fields[i]);
            if (this.fields[i].isEndLine) {
                this.rows.push(currentRow);
                currentRow = {fields: []};
            }
        }
        if (currentRow.fields.length > 0) {
            this.rows.push(currentRow);
        }

        this.initBlockDependencies(this.options.depends, this.$rootScope, this.fillContainers.bind(this));

        this.$rootScope.onEvent(this.$scope, 'refresh:' + this.options.name, () => {
            if (this.checker()) {
                this.fillContainers();
            }
        });

        var customizeFields = screenService[this.options.name + 'CustomizeFields'];
        if (customizeFields) {
            customizeFields(this.fields);
        }
    }

    fillContainers() {
        detailsBuilderService.getDetails(this.options.controller,
            this.rows,
            this.contextState,
            this.options.depends,
            this.dataSourceFilter,
            this.httpService).then(rows => this.rows = rows);
    }

    $onDestroy() {
        super.destroy();
    }
}
export default {
    template: template,
    require: {
        screenCtrl: "^screen"
    },
    bindings: {
        name: "@"
    },
    controller: DetailsBlockController
}