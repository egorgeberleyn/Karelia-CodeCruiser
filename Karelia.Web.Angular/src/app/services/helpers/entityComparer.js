export function compareEntities(a, b) {
    if (angular.isUndefined(a) && angular.isUndefined(b))
        return true;
    if ((angular.isUndefined(a) && b) || (a && angular.isUndefined(b)))
        return false;
    return a.uid === b.uid;
};
