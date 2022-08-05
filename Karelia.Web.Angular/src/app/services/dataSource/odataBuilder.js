export function buildQuery(relativePath, paging, sorts = [], filtering) {
    const { dataSourceFilter, globalFilter, filter, quickSearchFilter } = filtering;
    const { lastPage, count, top, pageSize, page } = paging;
    let first;
    let needSeparator = relativePath.indexOf('?$') !== -1;
    let params = relativePath.indexOf('?$') !== -1 ? '' : '?';
    if (count) {
        if (needSeparator) {
            params += '&';
        }
        params += '$count=true';
        needSeparator = true;
    }
    if ((typeof lastPage !== 'undefined') && !top) {
        if (needSeparator) {
            params += '&';
        }
        params += `$top=${pageSize}`;
        if (lastPage > 1) {
            let skip = (lastPage - 1) * pageSize;
            params += `&$skip=${skip}`;
        }
        needSeparator = true;
    }
    if (top) {
        if (needSeparator) {
            params += '&';
        }
        params += `$top=${top}`;
        needSeparator = true;
    }
    if (sorts && (sorts.length > 0)) {
        if (needSeparator) {
            params += '&';
        }
        params += addSorts(sorts);
        needSeparator = true;
    }
    if (quickSearchFilter && quickSearchFilter.query) {
        if (needSeparator) {
            params += '&';
        }
        params += addQuickSearchFilter(quickSearchFilter);
        needSeparator = true;
    }
    if (dataSourceFilter || (filter && (filter.filters.length > 0)) || (globalFilter && (globalFilter.filters.length > 0))) {
        let operator;
        let hasFilter = false;
        if (needSeparator) {
            params += '&';
        }
        if (filter && (filter.filters.length > 0)) {
            params += '$filter=';
            hasFilter = true;
            params += addFilters(filter);
        }
        if (dataSourceFilter) {
            if (hasFilter) {
                params += `+and+`;
            } else {
                params += `$filter=`;
            }
            //TODO fix it with complex example
            params += addFilters(dataSourceFilter.filters? dataSourceFilter: { filters: [dataSourceFilter] });
            hasFilter = true;
        }
        if (globalFilter && (globalFilter.filters.length > 0)) {
            if (!hasFilter) {
                params += '$filter=';
            } else {
                params += `+${globalFilter.logic}+`;
            }
            hasFilter = true;
            params += addFilters(globalFilter);
        }
    }

    return relativePath + params;
}

function addFilters(filter) {
    const functionOperators = ['contains', 'endswith', 'not contains', 'not substringof', 'startswith', 'substringof'];
    let filtersQuery = "";
    let first = true;
    for (let filterField of filter.filters) {
        if (!first) {
            filtersQuery += filter.logic ? `+${filter.logic}+` : '+or+';
        }
        if (filterField.filters && filterField.filters.length > 0) {
            filtersQuery += '(' + addFilters(filterField) + ')';
        }
        else if (functionOperators.includes(filterField.operator)) {
            filtersQuery += `${filterField.operator}(${filterField.field},'${encodeURIComponent(filterField.value)}')`;
        } else {
            const operator = filterField.operator ? filterField.operator : 'eq';
            let value = filterField.value;
            if (value === '') {
                value = "''";
            }
            else if (value !== null && isNaN(value) && !value.startsWith("'") && !value.endsWith("'")) {
                value = `'${encodeURIComponent(value)}'`;
            }
            filtersQuery += `${filterField.field}+${operator}+${value}`;
        }
        first = false;
    }
    return filtersQuery;
}

function addQuickSearchFilter(quickSearchFilter) {
    let filter = `filter=${encodeURIComponent(quickSearchFilter.query)}`;
    for (let field of Array.from(quickSearchFilter.fields)) {
        filter += `|${field}`;
    }
    return filter;
}

function addSorts(sorts) {
    let sortsQuery = '$orderby=';
    let first = true;
    for (let sort of Array.from(sorts)) {
        if (!first) {
            sortsQuery += ',';
        }
        sortsQuery += sort.name;
        if (sort.direction === 'desc') {
            sortsQuery += '+desc';
        }
        first = false;
    }
    return sortsQuery;
}
