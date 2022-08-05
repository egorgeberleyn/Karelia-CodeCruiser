import { SORTING } from "../../../../services/helpers/enums";
import DataSource from "../../../../services/dataSource/dataSource";
import { visibilityChecker } from "../../../../services/screens/visibilityChecker";

export default class BaseDataBlock {
    constructor() {
        this.destroyHandlers = [];
    }
 
    getDataSource(options, dataSourceFilter, httpService) {
        return new DataSource({
            paging: options.content.pagingEnabled ? {
                pageSize: options.content.itemsOnPage,
                count: true,
                lastPage: 1
            }: null,
            sorts: this._getInitialSort(options.content.fields),
            query: options.controller,
            filtering: {
                dataSourceFilter
            }
        }, httpService);
    }

    initVisibilityChecker(scope, element, callback) {
        this.checker = visibilityChecker(scope, element, () => {
            callback();
        });
    }

    _getInitialSort(fields) {
        const sortedField = fields.find(f => f.sorting !== 0);
        return sortedField? [{
            name: sortedField.field.name,
            direction: SORTING.toString(sortedField.sorting)
        }]: []
    }

    initBlockDependencies(depends, rootScope, dataFetchCallback) {
        if (depends) {
            for (let i = 0; i < depends.length; i++) {
                const dep = depends[i];
                const handler = rootScope.$on(dep.parent, () => {
                    if (this.checker()) {
                        dataFetchCallback();
                    }
                });
                this.destroyHandlers.push(handler);
            }
        } else {
            dataFetchCallback();
        }
    }

    destroy() {
        if (this.destroyHandlers)
            this.destroyHandlers.forEach(handler => {
                handler();
            });
    }
}