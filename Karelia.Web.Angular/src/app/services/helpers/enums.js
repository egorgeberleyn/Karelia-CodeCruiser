export const SORTING = {
    ASC: 1,
    DESC: 2,
    toString(value) {
        switch(value) {
            case SORTING.ASC:
                return 'asc';
            case SORTING.DESC:
                return 'desc';
            default: 
                return 'none';
        }
    }
}