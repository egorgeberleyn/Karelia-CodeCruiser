export function visibilityChecker(scope, element, callback) {
    const watcher = {
        value: element.is(':visible'),
        watcher: scope.$watch(function () {
            return element.is(':visible');
        }, (newvalue) => {
            if (!watcher.value && newvalue) {
                watcher.value = newvalue;
                callback();
            } else {
                watcher.value = newvalue;
            }
        })
    };
    return () => {
        return watcher.value;
    };
}

