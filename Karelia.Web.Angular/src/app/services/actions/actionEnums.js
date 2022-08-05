export const ActionPosition = {
    NONE: 0,
    CONTEXT: 1,
    TOOLBAR: 2,
    ALL: 3,

    isContext(value) {
        return value === ActionPosition.CONTEXT || value === ActionPosition.ALL;
    },

    isToolbar(value) {
        return value === ActionPosition.TOOLBAR || value === ActionPosition.ALL;
    }
}

export const ActionStatus = {
    NONE: 0,
    SUCCESS: 1,
    FAIL: 2,
    CANCELED: 3    
}