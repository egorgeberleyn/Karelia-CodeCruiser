import template from "./grid-block.html"
import { buildGlobalFilter } from "../../../../services/dataSource/filterBuilder";
import { ActionPosition } from "../../../../services/actions/actionEnums";
import { compareEntities } from "../../../../services/helpers/entityComparer";
import { createActionsByDeclaration } from "../../../../services/actions/actionConstructor";
import { downloadFile } from "../../../../services/screens/screenHelpers";
import BaseDataBlock from "./../base/baseDataBlock";

class GridBlockController extends BaseDataBlock {
    constructor($scope, $element, $rootScope, $translate, services, cancelableProgressService) {
        "ngInject";
        super();
        Object.assign(this, {
            $scope,
            $element,
            $rootScope,
            $translate,
						services,
						cancelableProgressService,
        });
        this.rootHandlers = [];
        this.data = { count: 0, value: [] };
    }

    $onInit() {
        this.contextState = this.screenCtrl.contextState;
        this.settings = this.screenCtrl.blocks[this.name];

        this.contextState[this.settings.name] = {};
        const screenService = this.contextState.screenService;

        const filterExtractor = screenService[`${this.settings.name}SourceFilter`];
        let dataSourceFilter;
        if (filterExtractor)
            dataSourceFilter = filterExtractor(this.contextState);

        this.dataSource = this.getDataSource(this.settings, dataSourceFilter, this.services.httpService);
        this.initVisibilityChecker(this.$scope, this.$element, this.fetchData.bind(this));
        this.initBlockDependencies(this.settings.depends, this.$rootScope, this.fetchData.bind(this));

        if (this.settings.actions && this.settings.actions.length > 0) {
            const allActions =  createActionsByDeclaration(this.services, this.settings.actions, screenService, false, this.contextState, this.settings.name);
            this.toolbarActions = allActions.filter(t => ActionPosition.isToolbar(t.position));
            this.contextActions = allActions.filter(t => ActionPosition.isContext(t.position));
            this.settings.hasToolbar = this.toolbarActions.length > 0;
        }

        if (this.settings.hasQuickFilter) {
            this.quickSearchFields = this.settings.content.fields.filter(field => {
                return field.field.supportByQuickFilter;
            }).map(field => {
                return {
                    id: field.field.name,
                    name: field.title
                }
            });
        }

        this.settings.hasToolbar = this.settings.hasToolbar || this.settings.hasQuickFilter;

        this.$scope.$on(`refresh:${this.settings.name}`, (event, args) => {
            if (this.checker()) {
                if (args && args.data && args.data.Data && args.data.Data.Object) {
                    this.fetchData();
                    this.$scope.$broadcast('updateSelectedRow', args.data.Data.Object);
                } else {
                    this.fetchData();
                }
            }
        });
    }

    onSelectRow(selectedItem) {
        if (!compareEntities(this.contextState[this.settings.name].activeItem, selectedItem)) {
            this.contextState[this.settings.name].activeItem = selectedItem;
            this.$rootScope.$broadcast(this.settings.name);
        }
    }

    fetchData() {
        this.dataSource.filtering.globalFilter = buildGlobalFilter(this.settings.depends, this.contextState);
        this.dataSource.getData().then(data => this.data = data);
    }

    onFilterChanged(filter) {
        this.dataSource.filtering.filter = filter;
        this.fetchData();
    }

    onSortChanged(sort) {
        if (this.multiplySorting) {
            const sortIndex = this.dataSource.sorts.findIndex(s => (s.name === sort.name));
            if (sortIndex === -1) {
                this.dataSource.sorts.push(sort);
            } else if (sort.direction === undefined) {
                this.dataSource.sorts.slice(sortIndex, 1);
            } else {
                this.dataSource.sorts[sortIndex] = sort;
            }
        } else {
            this.dataSource.sorts = [sort];
        }
        this.fetchData();
    }

    onPageChanged(pageSize, page) {
        this.dataSource.paging.lastPage = page;
        this.dataSource.paging.pageSize = pageSize;
        this.fetchData();
    }

    onFileLinkClicked(fileId, fileName) {
        downloadFile(fileId, 
            fileName, 
            this.services.httpService, 
            this.cancelableProgressService, 
            this.$translate.instant("cancelable_progress.downloading"));
    }

    onQuickSearch(text, selectedfield) {
        this.dataSource.paging.lastPage = 1;
        this.dataSource.filtering.quickSearchFilter = {
            query: encodeURIComponent(text),
            fields: selectedfield ? [selectedfield] : []
        };
        this.fetchData();
    }

    $onDestroy() {
        super.destroy();
    }
}

export default {
    template: template,
    require: {
        screenCtrl: '^screen'
    },
    bindings: {
        name: "@",
        multiplySorting: "<"
    },
    controller: GridBlockController
};
