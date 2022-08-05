import template from './grid.html'
import gridBlockService from './gridService'
import gridOptionsFactory from './gridOptionsFactory'
import screenSizeService from './../../../services/helpers/screenSizeService'

class GridController {
    constructor($timeout, $scope, popupActionMenuService) {
        "ngInject";
        Object.assign(this, { $timeout, $scope, popupActionMenuService });
        this.handlers = [];
    }

    $onInit() {
        this.wrapDataInGridCell = this.options.content.wrapDataInGridCell;
        this.$scope.$on('updateSelectedRow', (item) => {
            const selectedItem = this.grid.dataItem(this.grid.select());
            this.selectedUid = selectedItem.uid;
            const keys = Object.keys(item);
            for (let key of keys) {
                selectedItem.set(key, item[key]);
            }
        });

        this.gridName = "grid" + this.options.name;
        if (this.contextActions && this.contextActions.length > 0) {
            this._contextActionMenu = this.popupActionMenuService.createMenu(this.contextActions, 'actionMenu' + this.gridName);
        }

        this.gridOptions = gridOptionsFactory.createGridOptions(this.options.content,
            this.contextActions,
            this.gridName,
            screenSizeService.isSmall(),
            this.multiplySorting);

        this.gridOptions.dataBound = (e) => {
            const grid = e.sender;
            let row;
            if (!this.selectedUid) {
                row = grid.tbody.find('tr')[0];
            } else {
                row = grid.tbody.find(">tr[data-uid='" + this.selectedUid + "']");
                this.selectedUid = undefined;
            }
            this._selectGridRow(row, grid, true);
        };

        this.$scope.$on("kendoWidgetCreated", (event, widget) => {
            const pagerChanged = (page) => {
                const grid = this.grid;
                this.onPageChanged({ pageSize: grid.pager.pageSize(), page });
            };
            if (widget === this.grid) {
                const grid = this.grid;
                if (this.data) {
                    grid.dataSource.read(this.data);
                }
                if (this.options.content.pagingEnabled) {
                    const pageSizeDropDownList = grid.wrapper.children(".k-grid-pager").find("select").data("kendoDropDownList");

                    pageSizeDropDownList.bind("change", (e) => {
                        pagerChanged(1);
                    });

                    this.handlers.push(() => {
                        pageSizeDropDownList.unbind('change');
                    });

                    grid.pager.bind('change', (e) => {
                        pagerChanged(e.index);
                    });
                    this.handlers.push(() => {
                        if (grid.pager)
                            grid.pager.unbind('change');
                    })
                }
                grid.bind('sort', (e) => {
                    const sort = { name: e.sort.field, direction: e.sort.dir };
                    this.onSortChanged({ sort });
                });
                this.handlers.push(() => {
                    grid.unbind('sort');
                });
                grid.bind('filter', (e) => {
                    let currentFilter = e.sender.dataSource.filter();
                    if (!currentFilter) {
                        currentFilter = {
                            filters: e.filter.filters,
                            logic: e.filter.logic
                        };
                    } else {
                        if (!e.filter) {
                            currentFilter.filters.splice(currentFilter.filters.findIndex(f => f.field === e.field), 1);
                        } else {
                            const index = currentFilter.filters.findIndex(f => f.field === e.filter.filters[0].field);
                            if (index >= 0) {
                                currentFilter.filters[index] = e.filter.filters[0];
                            } else {
                                currentFilter.filters.push(e.filter.filters[0]);
                            }
                        }
                    }
                    this.onFilterChanged({ filter: currentFilter });
                });
                this.handlers.push(() => {
                    grid.unbind('filter');
                });
            }
        });

        const self = this;
        this.gridOptions.change = function () {
            const dataItem = this.dataItem(this.select());
            self.onSelectRow({ selectedItem: dataItem });
        };

        this.screenSizeCleaner = screenSizeService.addChangeScreenSizeListener(() => {
            this._resizeGrid();
        });
    }

    $onChanges(e) {
        if (this.grid && e.data && e.data.currentValue) {
            this.grid.dataSource.read(e.data.currentValue);
        }
    }

    _resizeGrid() {
        this.$timeout(() => {
            gridBlockService.resizeGrid(this.gridName);
            if (this.options.content.pagingEnabled) {
                const grid = this.grid;
                const element = grid.element;
                if (element.outerWidth(true) < 500) {
                    this.gridSmall = true;
                } else {
                    this.gridSmall = false;
                }
                const numbers = element.find('.k-pager-numbers');
                const numbersHeight = numbers.children().length * numbers.outerHeight(true);
                const gridArea = element.outerHeight(true) - numbers.outerHeight(true);
                if (numbersHeight > gridArea) {
                    grid.pager.options.buttonCount = 3;
                } else {
                    grid.pager.options.buttonCount = 10;
                }
                grid.pager.refresh();
            }            
        });
    }

    _selectGridRow(rowSelector, grid, autoSizeColumns) {
        if (!rowSelector) {
            this.onSelectRow({ selectedItem: undefined });
        } else {
            if (autoSizeColumns && !screenSizeService.isSmall()) {
                if (grid.table.is(':visible')) {
                    gridBlockService.autoFitColumns(grid);
                } else {
                    const wacher = this.$scope.$watch(() => {
                        return grid.table.is(':visible')
                    }, newvalue => {
                        if (newvalue) {
                            gridBlockService.autoFitColumns(grid);
                            wacher();
                        }
                    });
                }
            }
            grid.select(rowSelector);
        }
        this._resizeGrid();
    }
    fileLinkClicked(fileId, fileName) {
        this.onFileLinkClicked({ fileId: fileId, fileName: fileName });
    }
    contextMenuButtonClicked(id, $event) {
        if (this._contextActionMenu !== null) {
            this._contextActionMenu.show($event);
        }
    }

    get grid() {
        return this.$scope[this.gridName];
    }

    $onDestroy() {
        if (this._contextActionMenu) {
            this._contextActionMenu.destroy();
        }
        this.handlers.forEach(h => h());
        this.screenSizeCleaner();
    }
}
export default {
    template: template,
    bindings: {
        options: "<",
        contextActions: "<",
        data: "<",
        multiplySorting: "<",
        onSelectRow: "&",
        onFileLinkClicked: "&",
        onFilterChanged: "&",
        onSortChanged: "&",
        onPageChanged: "&"
    },
    controller: GridController
}

