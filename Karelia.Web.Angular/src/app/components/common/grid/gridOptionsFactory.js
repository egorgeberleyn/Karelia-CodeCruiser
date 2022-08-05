import dataTypeHelperService from './../../../services/helpers/dataTypeHelperService';
import { SORTING } from '../../../services/helpers/enums';

const NUMBER_VISIBLE_COLUMNS_MOBILE = 1;

class GridOptionsFactory {
    _getActionsColumn(gridName) {
        var column = {
            title: " ",
            field: "Action",
            template: '<div ng-click="$ctrl.contextMenuButtonClicked(' + "#='uid'#" + ', $event)" class="grid-context-menu-button grid-{{$ctrl.gridName}}"></div><div class="gridContextMenu' + gridName + '#=uid#"></div>',
            width: "40px",
            sortable: false,
            filterable: false,
            //locked: true,
            lockable: false,
            menu: false,
            resizable: false
        };
        return column;
    }

    _getFileLinkTemplate(colName) {
        return "<a href='' ng-click='$ctrl.fileLinkClicked(\"#=" + colName + " ? " + colName + ".Id: ''#\", \"#=" + colName + " ? " + colName + ".FileName: ''#\")' > #=" + colName + " ? " + colName + ".FileName: ''# </a>";
    }

    _getFormatTemplate(colName, columnDescr) {
        return `{{ dataItem.${colName} | formatterFilter:${columnDescr.field.dataType}:${columnDescr.format} }}`
    }

    _getCheckboxTemplate(gridName, columnDescr) {
        return `<input type="checkbox" id="${gridName + columnDescr.field.name}CheckBox#=uid#" #= ${columnDescr.field.name}? "checked=checked" : "" # disabled="disabled" ></input><label for="${gridName + columnDescr.field.name}CheckBox#=uid#"></label>`
    }

    _getColumnTemplate(columnDescr, gridName) {
        const type = dataTypeHelperService.toJSType(columnDescr.field.dataType);
        const colName = columnDescr.field.name;
        return type === 'none' ? this._getFileLinkTemplate(colName)
        : columnDescr.format !== undefined ? this._getFormatTemplate(colName, columnDescr) :
            dataTypeHelperService.isBool(columnDescr.field.dataType) ? this._getCheckboxTemplate(gridName, columnDescr) : null
    }

    _createColumn(columnDescr, gridName) {
        const type = dataTypeHelperService.toJSType(columnDescr.field.dataType);
        return {
            title: columnDescr.title,
            template: this._getColumnTemplate(columnDescr, gridName),
            field: type !== 'none' ? columnDescr.field.name : null,
            sortable: true,
            hidden: columnDescr.hidden,
            width: columnDescr.width ? columnDescr.width + "px" : null,
            sorting: columnDescr.sorting
        };
    }

    _createColumns(columnsDescr, gridName) {
        return columnsDescr.map((columnDescr) => {
            return this._createColumn(columnDescr, gridName);
        });
    }

    _getDetailTemplate(columnDescriptions, gridName) {
        let template = `<div class='grid-row-details k-block'><ul>`;
        for (let i=0; i < columnDescriptions.length; i++) {
            const columnDescr = columnDescriptions[i];
            const columnTemplate = this._getColumnTemplate(columnDescr, gridName);
            if (columnTemplate) {
                template += `<li><label>${columnDescr.title}:</label>${columnTemplate}</li>`
            } else {
                template += `<li><label>${columnDescr.title}:</label>#=${columnDescr.field.name}#</li>`
            }
        }

        template += `</ul></div>`
        return template;
    }

    createGridOptions(options, actions, gridName, mobile, multiplySorting) {
        const columns = this._createColumns(mobile? options.fields.slice(0, NUMBER_VISIBLE_COLUMNS_MOBILE): options.fields, gridName);
        if (actions && actions.length > 0) {
            columns.unshift(this._getActionsColumn(gridName));
        }
        const gridOptions = {
            dataSource: this.getDataSource(columns),
            selectable: "row",
            pageable: options.pagingEnabled ? {
                pageSize: options.itemsOnPage,
                pageSizes: [5, 25, 50, 100]
            } : false,
            filterable: true,
            columnMenu: true,
            resizable: true,
            columns,
            sortable: multiplySorting === true || multiplySorting === undefined ? {
                mode: "multiple"
            }: true
        };
        if (mobile && options.fields.length > NUMBER_VISIBLE_COLUMNS_MOBILE) {
            gridOptions.detailTemplate = this._getDetailTemplate(options.fields.slice(NUMBER_VISIBLE_COLUMNS_MOBILE));
        }
        return gridOptions;
    }

    getDataSource(columns) {
        let sort = {};
        const model = {
            id: 'Id',
            fields: {}
        };
        for (var i = 0; i < columns.length; i++) {
            const column = columns[i];
            model.fields[column.field] = {
                type: column.type,
                sortable: column.sortable
            };
            if (column.sorting !== 0) {
                sort = {
                    field: column.field,
                    dir: SORTING.toString(column.sorting)
                }
            }
        }
        return {
            transport: {
                read: (operation) => {
                    operation.success(operation.data || []);
                },
                cache: false
            },
            schema: {
                data: data => data.value,
                total: data => data.count,
                model
            },
            serverPaging: true,
            serverSorting: true,
            sort
        }
    }
}
export default new GridOptionsFactory();
