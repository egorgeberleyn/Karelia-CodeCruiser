export function buildGlobalFilter (depends, contextState) {
    const globalFilter = {
        logic: 'and',
        filters: [],
        depIsNull: false
    };
    if (depends) {
        for (let i = 0; i < depends.length; i++) {
            let dep = depends[i];
            if (contextState[dep.parent] && contextState[dep.parent].activeItem) {
                for (let j = 0; j < dep.fields.length; j++) {
                    globalFilter.filters.push({
                        field: dep.fields[j],
                        operator: "eq", // TODO make operator depends from field type
                        value: contextState[dep.parent].activeItem[dep.parentFields[j]]
                    });
                }
            } else {
                globalFilter.depIsNull = true;
                break;
            }
        }
    }
    return globalFilter;
}