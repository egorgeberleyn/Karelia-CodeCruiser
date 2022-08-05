export function downloadFile(fileId, fileName, httpService, cancelableProgressService, cancelFormTitle) {
    const progressCallback = cancelableProgressService.show();
    progressCallback.setCaption(`${fileName} ${cancelFormTitle}`);
    httpService.downloadFile(fileId, fileName, progressCallback).then(() => {
        progressCallback.close();
    }).catch(error => {
        console.error(error);
        progressCallback.close();
    });
}

export function buildContextState(settings, rootScope, parameters) {
    const contextState = {
        actions: [],
        firstSplitterCreated: false,
        screenName: settings.name,
        refresh: (screenBlocks) => {
            screenBlocks.forEach(blockName => {
                rootScope.$broadcast('refresh:' + blockName);
            });
            return Promise.resolve({});
        },
        parameters: {},
        refreshItem: (blockName, actionResult) => {
            rootScope.$broadcast('refresh:' + blockName, actionResult);
        },
        addDependency: (depName, method) => {
            if (!contextState.actionDependencies[depName]) {
                const watcher = rootScope.$on(depName, () => {
                    contextState.actionDependencies[depName].callbacks.forEach(
                        callback => {
                            callback();
                        });
                });
                contextState.actionDependencies[depName] = {
                    name: depName,
                    callbacks: [method],
                    watcher: watcher
                };
            } else {
                contextState.actionDependencies[depName].callbacks.push(method);
            }
        },
        actionDependencies: {}
    };
    return contextState;
}